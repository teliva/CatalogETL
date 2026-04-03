-- Create new table to store embeddings that are generated for an IDB.
CREATE TABLE ProductEmbeddings (
    ProductId INT FOREIGN KEY NOT NULL,
    Product_DescriptionEmbeddings VARCHAR(MAX)

    CONSTRAINT FK_Embeddings_Products FOREIGN KEY (ProductId) 
    REFERENCES Product(ProductId)
);