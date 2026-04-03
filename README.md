# CatalogETL

Projects that are used to generate embeddings for Catalog/Product data and a search service that will use cosine similarity for product search queries.

## Description

This repository contains several projects that enable vector search for products using cosine similarity. Using an open source model (BERT) embeddings are generated for products in the intermediate database. Additionally there is a service that will allow users to query and will report results.

## Projects

### CatalogDataTransformer
C# Project that will injest Product Catalog data and generate the embeddings.

### DBMigration
Contains scripts for updating Microsoft SQL DB schema.

## Setup
To setup this projects another document has been created in ./Documents/SETUP.md


## Goals
1. Create a command line tool that will allow you to easily vector search data.
2. Formalize the pipeline to create files for specification objects.
3. Do data research to invert the tree data structure to simplify for user interaction.
4. Use text classification to try and create labels for the option structure.



