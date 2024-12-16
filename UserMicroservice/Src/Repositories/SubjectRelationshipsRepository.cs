using user_microservice.Src.Data;
using user_microservice.Src.Models;
using user_microservice.Src.Repositories.Interfaces;

namespace user_microservice.Src.Repositories
{
    public class SubjectRelationshipsRepository : GenericRepository<SubjectRelationship>,
                                                ISubjectRelationshipsRepository
    {
        public SubjectRelationshipsRepository(DataContext context) : base(context)
        {
        }
    }
}