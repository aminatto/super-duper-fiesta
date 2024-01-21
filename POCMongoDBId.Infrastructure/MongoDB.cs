using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace POCMongoDBId.Infrastructure
{
    public class MongoDB
    {
        public IMongoDatabase DB { get; set; }

        public MongoDB(IConfiguration configuration)
        {
            try
            {
                var settings = MongoClientSettings.FromUrl(new MongoUrl(configuration["ConnectionString"]));
                var client = new MongoClient(settings);
                DB = client.GetDatabase(configuration["DbName"]);
            }
            catch (Exception e)
            {

                throw new MongoException("Unable to connect to MongoDB", e);
            }
        }
    }
}
