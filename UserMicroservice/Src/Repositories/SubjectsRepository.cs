using user_microservice.Src.Data;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;

namespace user_microservice.Src.Repositories
{
    public class SubjectsRepository : GenericRepository<Subject>, ISubjectsRepository
    {
        public SubjectsRepository(DataContext context): base(context)
        {
        }
    }
}