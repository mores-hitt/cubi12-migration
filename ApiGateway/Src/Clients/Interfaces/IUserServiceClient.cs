using Shared.Library.Protos;

namespace ApiGateway.Src.Clients.Interfaces
{
    public interface IUserServiceClient 
    {
        public Task<Shared.Library.Protos.UserDto> GetUserAsync(string token);

        public Task<Shared.Library.Protos.GetUserProgressResponse> GetUserProgressAsync(string token);

        public Task SetUserProgressAsync(Shared.Library.Protos.UpdateUserProgressDto updateUserProgress, string token);

        public Task<Shared.Library.Protos.UserDto> EditProfile(Shared.Library.Protos.EditProfileDto user, string token); 
    }
}