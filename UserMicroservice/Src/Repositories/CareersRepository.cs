using user_microservice.Src.Data;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;

namespace user_microservice.Src.Repositories
{
    public class CareersRepository : GenericRepository<Career>, ICareersRepository
    {
        public CareersRepository(DataContext context) : base(context)
        {
        }
    }
}