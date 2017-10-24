using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using com.Entities;

namespace com.MongoCache
{
    public class MongoConnector
    {

        private MongoClient _mongoClient;
        private static string _connectionString = "mongodb://localhost:27017";

        public MongoClient MongoClient {
            get { return _mongoClient; }
        }

        public MongoConnector()
        {
            var mongoSettings = new MongoClientSettings {
                UseSsl = false,
                Server = new MongoServerAddress("localhost", 27017)
            };

            _mongoClient = new MongoClient(mongoSettings);
        }

        public IMongoDatabase GetMongoDb(string dbName)
        {
            return _mongoClient.GetDatabase(dbName);
        }

        public IMongoCollection<BsonDocument> GetCollection(IMongoDatabase db, string collectionName)
        {
            return (db.GetCollection<BsonDocument>(collectionName));
        }

        public async Task<IAsyncCursor<BsonDocument>> GetDocumentAsync(IMongoCollection<BsonDocument> collection, BsonDocument filterDoc)
        {
          return await collection.FindAsync(filterDoc);
        }

        public async Task<IAsyncCursor<BsonDocument>> GetDocumentAsycn(IMongoCollection<BsonDocument> collection, string filterCondition)
        {
            return await collection.FindAsync(filterCondition);
        }

    }
}
