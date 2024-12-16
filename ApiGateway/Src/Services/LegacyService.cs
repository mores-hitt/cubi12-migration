using ApiGateway.Src.DTOs.Resources;
using ApiGateway.Src.Clients.Interfaces;
using ApiGateway.Src.Services.Interfaces;

namespace ApiGateway.Src.Services
{
      public class LegacyService : ILegacyService
      {
            private readonly ILegacyServiceClient _legacyServiceClient;

            public LegacyService(ILegacyServiceClient legacyServiceClient)
            {
                  _legacyServiceClient = legacyServiceClient;
            }

            public async Task<List<SubjectResourceDto>> GetAllSubjectResources()
            {
                  return await _legacyServiceClient.GetAllSubjectResources();
            }

            public async Task<List<ResourceDto>> GetSubjectResourceById(int id)
            {
                  return await _legacyServiceClient.GetSubjectResourceById(id);
            }
      }
}