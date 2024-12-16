using Auth.Src.Models;

namespace Auth.Src.Repositories.Interfaces
{
    public interface IBlackListRepository 
    {
        public Task AddToken(string token);

        public Task<bool> IsTokenBlacklisted(string token);
    }
}