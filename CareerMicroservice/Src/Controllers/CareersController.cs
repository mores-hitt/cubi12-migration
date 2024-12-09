using Career.Src.Services.Interfaces;
using Grpc.Core;
using Shared.Library.Protos;

namespace Career.Src.Controllers
{
    public class CareersController : CareerGrpc.CareerGrpcBase
    {
        private readonly ICareersService _careersService;

        public CareersController(ICareersService careersService)
        {
            _careersService = careersService;
        }

        public override async Task<Careers> GetAll(Empty request, ServerCallContext context)
        {
            var careers = await _careersService.GetAll();


            var response = new Careers();

            response.Careers_.AddRange(careers);

            return response;
        }
    }
}