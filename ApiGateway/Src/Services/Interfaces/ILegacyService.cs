using ApiGateway.Src.DTOs.Resources;
namespace ApiGateway.Src.Services.Interfaces
{
    public interface ILegacyService
    {
        public Task<List<SubjectResourceDto>> GetAllSubjectResources();
        public Task<List<ResourceDto>> GetSubjectResourceById(int id);
    }
}