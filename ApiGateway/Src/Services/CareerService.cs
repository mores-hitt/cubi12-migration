using ApiGateway.Src.DTOs.Models;
using ApiGateway.Src.Clients.Interfaces;
using ApiGateway.Src.Services.Interfaces;

namespace ApiGateway.Src.Services
{
    public class CareerService : ICareerService
    {

        private readonly ICareerServiceClient _careerServiceClient;

        public CareerService(ICareerServiceClient careerServiceClient)
        {
            _careerServiceClient = careerServiceClient;
        }
        public async Task<List<CareerDto>> GetAll()
        {
            var careers = await _careerServiceClient.GetCareersAsync();
            return careers.Careers_.Select(c => new CareerDto
            {
                Name = c.Name,
                idCode = c.IdCode
            }).ToList();
        }
    }
}

