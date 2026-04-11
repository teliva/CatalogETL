# PGApi

A small FastAPI-based Python API that connects to the Postgres `productdb` database.

## Build and run with Docker

From the repository root:

```bash
cd Docker
docker-compose up --build pgapi
```

Then open:

- `http://localhost:8000/health`
- `http://localhost:8000/products`
- `http://localhost:8000/products/{product_id}`

## Environment

The service uses `DATABASE_URL`, defaulting to:

```text
postgresql://myuser:mysecretpassword@db:5432/productdb
```

If you need to customize it, set `DATABASE_URL` in the service environment.
