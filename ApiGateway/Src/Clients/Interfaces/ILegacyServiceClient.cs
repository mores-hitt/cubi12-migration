using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Src.DTOs.Resources;

namespace ApiGateway.Src.Clients.Interfaces
{
    public interface ILegacyRepository
    {
        public Task<List<SubjectResourceDto>> GetAllSubjectResources();
        public Task<List<ResourceDto>> GetSubjectResourceById(int id);
    }
}