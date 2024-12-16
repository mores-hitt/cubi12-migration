using ApiGateway.Src.DTOs.Models;

namespace ApiGateway.Src.Services.Interfaces
{
    public interface ICareerService
    {
        public Task<List<CareerDto>> GetAll();
    }
}