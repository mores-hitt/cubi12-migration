using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Career.Src.Data
{
    public class DataContext
    {
        private readonly IMongoDatabase _database;

        public DataContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetSection("ConnectionStrings:MongoDB").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new ArgumentNullException(nameof(connectionString), "The MongoDB connection string is not configured.");
            }

            var client = new MongoClient(connectionString);
            _database = client.GetDatabase("Career_thiscolony");
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }

        public IMongoCollection<Models.Career> Careers => _database.GetCollection<Models.Career>("Careers");
        
    }
}