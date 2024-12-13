using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.Clients.Interfaces;
using Shared.Library.Protos;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ApiGateway.Src.Services{
    public class UserService : IUserService{

        private readonly IUserServiceClient _userServiceClient;

        public UserService(IUserServiceClient userServiceClient)
        {
            _userServiceClient = userServiceClient;
        }

        public async Task<UserDto> GetProfile()
        {
            var user = await _userServiceClient.GetUserAsync();
            return new UserDto
            {
                Name = user.Name,
                FirstLastName = user.FirstLastName,
                SecondLastName = user.SecondLastName,
                Rut = user.Rut,
                Email = user.Email,
                Career = user.Career
            };
        }

        public async Task<List<UserProgressDto>> GetUserProgress()
        {
            var userProgress = await _userServiceClient.GetUserProgressAsync();
            return userProgress.UserProgress.Select(c => new UserProgressDto
            {
                Id = c.Id,
                SubjectCode = c.SubjectCode,
            }).ToList();

        }

        public async Task SetUserProgress(UpdateUserProgressDto updateUserProgress)
        {
            await _userServiceClient.SetUserProgressAsync(updateUserProgress);
            return;
            
        }

        public async Task<UserDto> EditProfile(EditProfileDto user)
        {
            await _userServiceClient.EditProfile(user);
            return new UserDto
            {
                Name = user.Name,
                FirstLastName = user.FirstLastName,
                SecondLastName = user.SecondLastName
            };
        }
    }
}