-- Load product data from DataCache/CatalogProducts_186000001.json into the Postgres product table.
-- Run from the repository root:
--   cd /home/ivan/Repos/CatalogETL
--   psql -d productdb -f Migrations/load_products_from_json.sql

\set ON_ERROR_STOP on
\echo Loading products from DataCache/CatalogProducts_186000001.json
\set content `cat DataCache/CatalogProducts_186000001.json`

INSERT INTO product (productid, modelnumber, pceproduct, description, enhanceddescription)
SELECT productId, modelNumber, pceProduct, description, enhancedDescription
FROM jsonb_to_recordset(:'content'::jsonb) AS x(
    productId int,
    modelNumber text,
    pceProduct boolean,
    description text,
    enhancedDescription text
)
ON CONFLICT (productid) DO UPDATE
SET
    modelnumber = EXCLUDED.modelnumber,
    pceproduct = EXCLUDED.pceproduct,
    description = EXCLUDED.description,
    enhanceddescription = EXCLUDED.enhanceddescription;
