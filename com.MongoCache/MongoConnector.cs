using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Bson;
using com.Entities;
using System.Collections.ObjectModel;

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

        public IMongoCollection<Movie> GetCollection(IMongoDatabase db, string collectionName)
        {
            return (db.GetCollection<Movie>(collectionName));
        }

        public IMongoCollection<Movie> GetCollection(string dbName, string collectionName)
        {
            return GetCollection(_mongoClient.GetDatabase(dbName), collectionName);
        }

        public async Task<IAsyncCursor<BsonDocument>> GetDocumentAsync(IMongoCollection<BsonDocument> collection, BsonDocument filterDoc)
        {
            return await collection.FindAsync(filterDoc);
        }

        public Movie GetDocumentByMovieId(IMongoCollection<Movie> collection, int id)
        {
            var filter = Builders<Movie>.Filter.Eq(d=>d.MovieId ,id);
            var cursor= collection.FindAsync(filter);
            return cursor.Result.First<Movie>();
        }

        public void AddDocument(string dbName, string collectionName, Movie movie)
        {
            var mongoDb = GetMongoDb(dbName);
            var collection = GetCollection(mongoDb, collectionName);
            collection.InsertOne(movie);        
        }

        public Collection<Movie> SearchMovies(string dbName, string collectionName, FilterDefinition<Movie> filterDef)
        {
            var collection = GetCollection(dbName, collectionName);
            Collection<Movie> movies = new Collection<Movie>();
            collection.FindSync(filterDef).ForEachAsync(d => movies.Add(d));
            return movies;
        }

        public Task<ReplaceOneResult> UpdateMovieAsync(string dbName, string collectionName, int id, Movie movie)
        {
            var mongodb = GetMongoDb(dbName);
            var collection = GetCollection(mongodb, collectionName);

            var filter = Builders<BsonDocument>.Filter.Eq("movieId", id);
            
            var result = collection.ReplaceOneAsync(
                filter: new BsonDocument("movieId", id.ToString()),
                options: new UpdateOptions { IsUpsert = true },
                replacement: movie);

            return result;
        }

        public Collection<Movie> GetAllDocuments(string dbName,string collectionName)
        {
            Collection<Movie> movies = new Collection<Movie>();
            GetCollection(dbName, collectionName).Find<Movie>("",null).ForEachAsync(d => movies.Add(d));
            return movies;            
        }
    }
}
