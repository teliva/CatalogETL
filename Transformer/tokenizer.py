from mongodal import get_all_documents, save_doc
from sentence_transformers import SentenceTransformer
import torch


data = get_all_documents()

model = SentenceTransformer('all-MiniLM-L6-v2')

for doc in data:
    embedding = model.encode(doc['enhancedDescription'])
    doc["embedding"] = embedding.tolist()  # convert to list for MongoDB

save_doc(data)