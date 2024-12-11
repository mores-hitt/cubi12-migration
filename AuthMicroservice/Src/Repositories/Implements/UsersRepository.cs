using System.Linq.Expressions;
using Auth.Src.Data;
using Auth.Src.Models;
using Auth.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Src.Repositories
{
    public class UsersRepository : GenericRepository<User>, IUsersRepository
    {
        private readonly Expression<Func<User, bool>> softDeleteFilter = x => x.DeletedAt == null;

        public UsersRepository(DataContext context) : base(context) { }

        public async Task<List<User>> GetAll()
        {
            var users = await dbSet
                            .Where(softDeleteFilter)
                            .Include(x => x.Role)
                            .Include(x => x.Career)
                            .ToListAsync();
            return users;
        }

        public async Task<User?> GetByEmail(string email)
        {
            var user = await dbSet
                        .Where(softDeleteFilter)
                        .Include(x => x.Role)
                        .Include(x => x.Career)
                        .FirstOrDefaultAsync(x => x.Email == email);
            return user;
        }

        public async Task<User?> GetByRut(string rut)
        {
            var user = await dbSet
                        .Where(softDeleteFilter)
                        .Include(x => x.Role)
                        .Include(x => x.Career)
                        .FirstOrDefaultAsync(x => x.RUT == rut);
            return user;
        }
    }
}