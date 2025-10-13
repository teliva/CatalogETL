using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MongoDAL;

public static class MongoDBContext
{
    public static async Task populateCatalogJson(string catalogJson)
    {
        var connectionString = "mongodb://localhost:27017/";
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("KITSProduct");
        var collection = database.GetCollection<BsonDocument>("Catalog");

        var document = BsonDocument.Parse(catalogJson);

        await collection.InsertOneAsync(document);
    }

    public static async Task populateProductsJson(string jsonProducts)
    {
        var connectionString = "mongodb://localhost:27017/";
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("KITSProduct");
        var collection = database.GetCollection<BsonDocument>("Product");

        var document = BsonSerializer.Deserialize<List<BsonDocument>>(jsonProducts);

        await collection.InsertManyAsync(document);
    }
}
