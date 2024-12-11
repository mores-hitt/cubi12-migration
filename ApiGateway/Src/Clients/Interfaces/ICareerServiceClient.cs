using Shared.Library.Protos;

namespace ApiGateway.Src.Clients.Interfaces
{
    public interface ICareerServiceClient 
    {
        public Task<Shared.Library.Protos.Careers> GetCareersAsync();
    }
}