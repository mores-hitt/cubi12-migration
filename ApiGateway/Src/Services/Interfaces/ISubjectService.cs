namespace ApiGateway.Src.Services.Interfaces
{
    public interface ISubjectService
    {
        public Task<List<ApiGateway.Src.DTOs.Subjects.SubjectDto>> GetAll();

        public Task<List<ApiGateway.Src.DTOs.Subjects.SubjectRelationshipDto>> GetAllRelationships();

        public Task<Dictionary<string, List<string>>> GetAllPrerequisites();

        public Task<Dictionary<string, List<string>>> GetAllPostRequisites();

    }
}