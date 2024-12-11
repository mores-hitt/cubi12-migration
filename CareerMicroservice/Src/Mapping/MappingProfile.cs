using AutoMapper;
using Career.Src.Models;
using Shared.Library.Protos;

namespace Career.Src.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Define your mappings here
            CreateMap<Career.Src.Models.Career, Shared.Library.Protos.Career>()
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<Shared.Library.Protos.Career, Career.Src.Models.Career>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }
    }
}