using Career.Src.Data;
using Career.Src.Models;
using Career.Src.Repositories.Interfaces;
using MongoDB.Driver;
using MongoDB.Driver.Linq;


namespace Career.Src.Repositories
{
    public class CareersRepository : ICareersRepository
    {
        protected readonly IMongoCollection<Models.Career> _collection;

        public CareersRepository(DataContext context)
        {
            _collection = context.GetCollection<Models.Career>("Careers");
        }

        public async Task<List<Models.Career>> Get()
        {
            var query = _collection.AsQueryable();

            var finalResult = await query.ToListAsync();
            
            return finalResult;
        }

    }
}