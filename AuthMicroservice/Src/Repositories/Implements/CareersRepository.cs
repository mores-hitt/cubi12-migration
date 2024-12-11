using Auth.Src.Data;
using Auth.Src.Models;
using Auth.Src.Repositories.Interfaces;

namespace Auth.Src.Repositories
{
    public class CareersRepository : GenericRepository<Career>, ICareersRepository
    {
        public CareersRepository(DataContext context) : base(context)
        {
        }
    }
}