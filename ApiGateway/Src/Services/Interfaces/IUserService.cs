using Grpc.Core;
using Google.Protobuf.Collections;
using Shared.Library.Protos;
using ApiGateway.Src.DTOs.User;

namespace ApiGateway.Src.Services.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetProfile();

        public Task<List<UserProgressDto>> GetUserProgress();

        public Task SetUserProgress(ApiGateway.Src.DTOs.User.UpdateUserProgressDto updateUserProgress);

        public Task<UserDto> EditProfile(UpdateUserProfileDto user);
    }
}