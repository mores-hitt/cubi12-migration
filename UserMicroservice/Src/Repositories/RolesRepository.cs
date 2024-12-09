using user_microservice.Src.Data;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;

namespace user_microservice.Src.Repositories
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(DataContext context) : base(context)
        {
        }
    }
}