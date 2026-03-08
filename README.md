# CatalogETL

Projects that are used to generate embeddings for Catalog/Product data and a search service that will use cosine similarity for product search queries.

## Description

This repository contains several projects that enable vector search for products using cosine similarity. Using an open source model (BERT) embeddings are generated for products in the intermediate database. Additionally there is a service that will allow users to query and will report results.

## Projects

### CatalogDataTransformer
C# Project that will injest Product Catalog data and generate the embeddings.

### DBMigration
Contains scripts for updating Microsoft SQL DB schema.



### Notes
1. First version of the project is to create a python script that will user BERT to generate vector embeddings for a product search.