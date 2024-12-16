using AutoMapper;
using Auth.Src.DTOs.Auth;
using Auth.Src.DTO.Models;
using Auth.Src.Models;

namespace Auth.Src.Extensions
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Career, CareerDto>();
            CreateMap<Role, RoleDto>();
            CreateMap<User, UserDto>();
            CreateMap<User, LoginResponseDto>();
            CreateMap<RegisterStudentDto, User>();
        }
    }
}