using Career.Src.Models;

namespace Career.Src.Repositories.Interfaces
{
    public interface ICareersRepository
    {
        Task<List<Models.Career>> Get();
    }
}