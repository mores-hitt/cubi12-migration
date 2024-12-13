using Shared.Library.Protos;

namespace ApiGateway.Src.Clients.Interfaces
{
    public interface IUserServiceClient 
    {
        public Task<Shared.Library.Protos.UserDto> GetUserAsync();

        public Task<Shared.Library.Protos.GetUserProgressResponse> GetUserProgressAsync();

        public Task SetUserProgressAsync(Shared.Library.Protos.UpdateUserProgressDto updateUserProgress);

        public Task<Shared.Library.Protos.UserDto> EditProfile(Shared.Library.Protos.EditProfileDto user); 
    }
}