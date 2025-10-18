import numpy as np
from numpy.linalg import norm
from pymongo import MongoClient
from sentence_transformers import SentenceTransformer

def cosine_similarity(a, b):
    return np.dot(a, b) / (norm(a) * norm(b))

# The query description
query_text = "Steel Chair"

model = SentenceTransformer('all-MiniLM-L6-v2')

query_embedding = model.encode(query_text)

with MongoClient("mongodb://localhost:27017/") as client:
    db = client["KITSProduct"]
    collection = db["ProductEmbeddings"]
    
    # Fetch all documents
    docs = list(collection.find())
    
    # Compute similarity for each document
    for doc in docs:
        doc['similarity'] = cosine_similarity(np.array(doc['embedding']), query_embedding)
    
    # Sort by similarity descending
    top_3 = sorted(docs, key=lambda x: x['similarity'], reverse=True)[:3]
    
    for i, doc in enumerate(top_3, start=1):
        print(f"{i}. {doc['enhancedDescription']} → similarity: {doc['similarity']:.4f}")
