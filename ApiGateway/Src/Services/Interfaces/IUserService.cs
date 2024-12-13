using Grpc.Core;
using Google.Protobuf.Collections;
using Shared.Library.Protos;

namespace ApiGateway.Src.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetProfile();

        public Task<List<UserProgressDto>> GetUserProgress();

        public Task SetUserProgress(UpdateUserProgressDto updateUserProgress);

        public Task<UserDto> EditProfile(EditProfileDto user);
    }
}