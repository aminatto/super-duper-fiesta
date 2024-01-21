using MongoDB.Driver;
using POCMongoDBId.Core.Entities;

namespace POCMongoDBId.Infrastructure.Data
{
    public class MongoDBContext
    {
        private readonly IMongoDatabase _database;

        public MongoDBContext(string connectionString, string databaseName)
        {
            var clientSettings = MongoClientSettings.FromConnectionString(connectionString);
            var mongoClient = new MongoClient(clientSettings);

            _database = mongoClient.GetDatabase(databaseName);
        }


        public IMongoCollection<Item> ItemCollection => _database.GetCollection<Item>("ItemCollection");
    }
}
