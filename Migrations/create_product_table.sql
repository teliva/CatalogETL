-- Create the Product Table inside postgres
CREATE TABLE Product (
    productId INT PRIMARY KEY,
    modelNumber VARCHAR(50),
    pceProduct BIT,
    description TEXT,
    enhancedDescription TEXT,
    description_embedding vector(384)
);


