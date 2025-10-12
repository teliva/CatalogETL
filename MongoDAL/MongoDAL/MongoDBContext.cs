using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;

namespace MongoDAL;

public class MongoDBContext
{
    public async Task populateCatalogJson(string catalogJson)
    {
        var connectionString = "mongoDb://localhost:27017";
        var client = new MongoClient(connectionString);

        var database = client.GetDatabase("KITSProduct");
        var collection = database.GetCollection<BsonDocument>("Catalog");

        var document = BsonDocument.Parse(catalogJson);

        await collection.InsertOneAsync(document);
    }
}
