using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.Clients.Interfaces;
using Shared.Library.Protos;
using Microsoft.AspNetCore.Http.HttpResults;
using ApiGateway.Src.DTOs.User;

namespace ApiGateway.Src.Services{
    public class UserService : IUserService{

        private readonly IUserServiceClient _userServiceClient;
        private readonly IHttpContextAccessor _ctxAccessor;

        public UserService(IUserServiceClient userServiceClient, IHttpContextAccessor ctxAccessor)
        {
            _userServiceClient = userServiceClient;
            _ctxAccessor = ctxAccessor;
        }

        public async Task<UserDto> GetProfile()
        {
            var token = ExtractToken();
            var user = await _userServiceClient.GetUserAsync(token);
            Console.WriteLine(user);
            return new UserDto
            {
                Name = user.Name,
                FirstLastName = user.FirstLastName,
                SecondLastName = user.SecondLastName,
                Rut = user.Rut,
                Email = user.Email,
                Career = user.Career,
                Id = user.Id
            };
        }

        public async Task<List<UserProgressDto>> GetUserProgress()
        {
            var token = ExtractToken();
            var userProgress = await _userServiceClient.GetUserProgressAsync(token);
            Console.WriteLine(userProgress);
            return userProgress.UserProgress.Select(c => new UserProgressDto
            {
                Id = c.Id,
                SubjectCode = c.SubjectCode,
            }).ToList();

        }

        public async Task SetUserProgress(ApiGateway.Src.DTOs.User.UpdateUserProgressDto updateUserProgress)
        {
            var token = ExtractToken();
            var mappedUserProgress = new Shared.Library.Protos.UpdateUserProgressDto
            {
                AddSubjects = { updateUserProgress.add_subjects },
                DeleteSubjects = { updateUserProgress.delete_subjects }
            };
            await _userServiceClient.SetUserProgressAsync(mappedUserProgress, token);
            return;
            
        }

        public async Task<UserDto> EditProfile(UpdateUserProfileDto user)
        {
            var token = ExtractToken();
            var mappedEdit = new Shared.Library.Protos.EditProfileDto
            {
                Name = user.name,
                FirstLastName = user.first_last_name,
                SecondLastName = user.second_last_name,
            };
            var updateUser = await _userServiceClient.EditProfile(mappedEdit,token);
            return new UserDto
            {
                Name = updateUser.Name,
                FirstLastName = updateUser.FirstLastName,
                SecondLastName = updateUser.SecondLastName,
                Rut = updateUser.Rut,
                Email = updateUser.Email,
                Career = updateUser.Career,
                Id = updateUser.Id
            };
        }

        public string ExtractToken()
            {
                  var token = _ctxAccessor.HttpContext.Request.Headers["Authorization"].ToString()?.Split(" ").Last();
                  if (string.IsNullOrEmpty(token))
                  {
                        throw new UnauthorizedAccessException("Token not provided");
                  }
                  return token;
            }
    }
}