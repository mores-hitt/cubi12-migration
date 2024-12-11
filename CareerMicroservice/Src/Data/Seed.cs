using System.Text.Json;
using MongoDB.Bson;

namespace Career.Src.Data
{
    public class Seed
    {
        private static readonly ILogger<Seed> _logger = LoggerFactory.Create(builder => builder.AddConsole()).CreateLogger<Seed>();

        /// <summary>
        /// Seed the database with examples models in the json files if the database is empty.
        /// </summary>
        /// <param name="context">Database Context </param>
        public static void SeedData(DataContext context)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            CallEachSeeder(context, options);
        }

        /// <summary>
        /// Centralize the call to each seeder method
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        public static void CallEachSeeder(DataContext context, JsonSerializerOptions options)
        {
            SeedFirstOrderTables(context, options);
        }

        /// <summary>
        /// Seed the database with the tables that don't depend on other tables.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedFirstOrderTables(DataContext context, JsonSerializerOptions options)
        {
            SeedCareers(context, options);
        }

        /// <summary>
        /// Seed the database with the careers in the json file and save changes if the database is empty.
        /// </summary>
        /// <param name="context">Database context</param>
        /// <param name="options">Options to deserialize json</param>
        private static void SeedCareers(DataContext context, JsonSerializerOptions options)
        {
            try
            {
                var careersCollection = context.GetCollection<Models.Career>("Careers");

                // Eliminar la colección existente (opcional)
                careersCollection.Database.DropCollection("Careers");

                var path = "Src/Data/DataSeeders/CareersData.json";
                var careersData = File.ReadAllText(path);
                var careersList = JsonSerializer.Deserialize<List<Models.Career>>(careersData, options) ??
                    throw new Exception("CareersData.json is empty");

                // Normalize the name and code of the careers
                careersList.ForEach(s =>
                {
                    s.Id = ObjectId.GenerateNewId().ToString();
                    s.Name = s.Name.ToLower();
                });

                _logger.LogInformation("Inserting {Count} careers into the database.", careersList.Count);
                careersCollection.InsertMany(careersList);
                _logger.LogInformation("Successfully inserted careers into the database.");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while seeding the careers.");
            }
        }
    }
}