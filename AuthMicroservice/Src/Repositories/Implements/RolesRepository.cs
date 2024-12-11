using Auth.Src.Data;
using Auth.Src.Models;
using Auth.Src.Repositories.Interfaces;

namespace Auth.Src.Repositories
{
    public class RolesRepository : GenericRepository<Role>, IRolesRepository
    {
        public RolesRepository(DataContext context) : base(context)
        {
        }
    }
}