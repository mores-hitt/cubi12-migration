using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Src.DTOs.Resources;
using Shared.Library.Protos;

namespace ApiGateway.Src.Clients.Interfaces
{
    public interface ISubjectServiceClient
    {
        public Task<Shared.Library.Protos.GetAllResponse> GetAllAsync();

        public Task<Shared.Library.Protos.GetAllRelationshipsResponse> GetAllRelationshipsAsync();

        public Task<Shared.Library.Protos.GetAllPrerequisitesResponse> GetAllPrerequisitesAsync();

        public Task<Shared.Library.Protos.GetAllPostRequisitesResponse> GetAllPostRequisitesAsync();
    }
}   