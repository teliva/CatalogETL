from pymongo import MongoClient

def get_collection(db_name="KITSProduct", collection_name="Product"):
    client = MongoClient("mongodb://localhost:27017/")
    db = client[db_name]
    return db[collection_name], client

def get_all_documents():
    collection, client = get_collection()
    documents = list(collection.find({}, {"modelNumber": 1, "enhancedDescription": 1, "_id": 0}))
    client.close()
    return documents


def save_doc(data):
    with MongoClient("mongodb://localhost:27017/") as client:
        db = client["KITSProduct"]
        collection = db["ProductEmbeddings"]
        result = collection.insert_many(data)