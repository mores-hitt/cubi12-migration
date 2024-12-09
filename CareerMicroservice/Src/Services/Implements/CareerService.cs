using Google.Protobuf.Collections;
using Career.Src.Repositories.Interfaces;
using Career.Src.Services.Interfaces;

namespace Career.Src.Services
{
    public class CareersService : ICareersService
    {
        private readonly ICareersRepository _careerRepository;
        private readonly IMapperService _mapperService;

        public CareersService(ICareersRepository careerRepository, IMapperService mapperService)
        {
            _careerRepository = careerRepository;
            _mapperService = mapperService;
        }

        public async Task<RepeatedField<Shared.Library.Protos.Career>> GetAll()
        {
             var careers = await _careerRepository.Get();
        

             return _mapperService.MapRepeatedField<Models.Career, Shared.Library.Protos.Career>(careers);
        }
    }
}   