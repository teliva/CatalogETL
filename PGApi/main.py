import os
from typing import List, Optional

import psycopg
from fastapi import FastAPI, HTTPException, Query
from pydantic import BaseModel
from sentence_transformers import SentenceTransformer

app = FastAPI(
    title="Catalog Postgres API",
    description="A small FastAPI service that connects to the Product Postgres database.",
    version="0.1.0",
)


class Product(BaseModel):
    productId: int
    modelNumber: Optional[str]
    pceProduct: bool
    description: Optional[str]
    enhancedDescription: Optional[str]


embedding_model = SentenceTransformer("all-MiniLM-L6-v2")


def get_database_url() -> str:
    return os.getenv(
        "DATABASE_URL",
        "postgresql://myuser:mysecretpassword@db:5432/productdb",
    )


def query_products(limit: int, offset: int):
    db_url = get_database_url()
    with psycopg.connect(db_url) as conn:
        with conn.cursor(row_factory=psycopg.rows.dict_row) as cur:
            cur.execute(
                "SELECT productid, modelnumber, pceproduct, description, enhanceddescription "
                "FROM product ORDER BY productid LIMIT %s OFFSET %s",
                (limit, offset),
            )
            return cur.fetchall()


def query_product(product_id: int):
    db_url = get_database_url()
    with psycopg.connect(db_url) as conn:
        with conn.cursor(row_factory=psycopg.rows.dict_row) as cur:
            cur.execute(
                "SELECT productid, modelnumber, pceproduct, description, enhanceddescription "
                "FROM product WHERE productid = %s",
                (product_id,),
            )
            return cur.fetchone()


def normalize_product(row: dict) -> Product:
    return Product(
        productId=row["productid"],
        modelNumber=row.get("modelnumber"),
        pceProduct=bool(row.get("pceproduct")),
        description=row.get("description"),
        enhancedDescription=row.get("enhanceddescription"),
    )


def get_embedding_source_rows():
    db_url = get_database_url()
    with psycopg.connect(db_url) as conn:
        with conn.cursor(row_factory=psycopg.rows.dict_row) as cur:
            cur.execute(
                "SELECT productid, COALESCE(enhanceddescription, description) AS text "
                "FROM product WHERE COALESCE(enhanceddescription, description) IS NOT NULL"
            )
            return cur.fetchall()


def update_product_embedding(product_id: int, embedding: List[float]):
    vector_literal = f"[{','.join(str(float(x)) for x in embedding)}]"
    db_url = get_database_url()
    with psycopg.connect(db_url) as conn:
        with conn.cursor() as cur:
            cur.execute(
                "UPDATE product SET description_embedding = %s::vector WHERE productid = %s",
                (vector_literal, product_id),
            )


def generate_description_embeddings():
    rows = get_embedding_source_rows()
    if not rows:
        return 0

    texts = [row["text"] for row in rows]
    product_ids = [row["productid"] for row in rows]
    embeddings = embedding_model.encode(texts, show_progress_bar=False)

    updated = 0
    for product_id, embedding in zip(product_ids, embeddings):
        update_product_embedding(product_id, embedding)
        updated += 1

    return updated


def bulk_load_products(products: List[Product]):
    db_url = get_database_url()
    with psycopg.connect(db_url) as conn:
        with conn.cursor() as cur:
            for product in products:
                cur.execute(
                    """
                    INSERT INTO product (productid, modelnumber, pceproduct, description, enhanceddescription)
                    VALUES (%s, %s, %s, %s, %s)
                    ON CONFLICT (productid) DO UPDATE SET
                        modelnumber = EXCLUDED.modelnumber,
                        pceproduct = EXCLUDED.pceproduct,
                        description = EXCLUDED.description,
                        enhanceddescription = EXCLUDED.enhanceddescription
                    """,
                    (
                        product.productId,
                        product.modelNumber,
                        product.pceProduct,
                        product.description,
                        product.enhancedDescription,
                    ),
                )
        return len(products)


@app.post("/products/embeddings/generate")
async def generate_product_embeddings():
    try:
        updated = generate_description_embeddings()
        return {"updated": updated}
    except Exception as exc:
        raise HTTPException(status_code=500, detail=str(exc))


@app.post("/products/bulk-load")
async def bulk_load(products: List[Product]):
    try:
        loaded = bulk_load_products(products)
        return {"loaded": loaded}
    except Exception as exc:
        raise HTTPException(status_code=500, detail=str(exc))


@app.get("/health")
async def health_check():
    try:
        db_url = get_database_url()
        with psycopg.connect(db_url) as conn:
            with conn.cursor() as cur:
                cur.execute("SELECT 1")
                cur.fetchone()
        return {"status": "ok"}
    except Exception as exc:
        raise HTTPException(status_code=503, detail=str(exc))


@app.get("/products", response_model=List[Product])
async def list_products(
    limit: int = Query(100, ge=1, le=1000),
    offset: int = Query(0, ge=0),
):
    rows = query_products(limit, offset)
    return [normalize_product(row) for row in rows]


@app.get("/products/{product_id}", response_model=Product)
async def get_product(product_id: int):
    row = query_product(product_id)
    if row is None:
        raise HTTPException(status_code=404, detail="Product not found")
    return normalize_product(row)
