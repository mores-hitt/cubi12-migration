using Auth.Src.Data;
using Auth.Src.Models;
using Auth.Src.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Auth.Src.Repositories
{
    public class BlacklistRepository : IBlackListRepository
    {
        private readonly DataContext _context;

        public BlacklistRepository(DataContext context)
        {
            _context = context;
        }

        public async Task AddToken(string token)
        {
            var blacklistedToken = new BlacklistedToken { Token = token, BlacklistedAt = DateTime.UtcNow };
            _context.BlackListToken.Add(blacklistedToken);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> IsTokenBlacklisted(string token)
        {
            return await _context.BlackListToken.AnyAsync(t => t.Token == token);
        }
    }
}