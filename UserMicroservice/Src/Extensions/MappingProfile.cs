using AutoMapper;
using user_microservice.Src.Models;
using Shared.Library.Protos;

namespace user_microservice.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Subject, SubjectDto>();
            CreateMap<SubjectRelationship, SubjectRelationshipDto>();
            CreateMap<User, UserDto>();
            CreateMap<Models.Career, CareerDto>();
            CreateMap<UserProgress, UserProgressDto>();
        }
    }
}