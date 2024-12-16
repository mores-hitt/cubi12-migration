using Grpc.Core;
using Google.Protobuf.Collections;
using Shared.Library.Protos;

namespace user_microservice.Src.Services.Interfaces
{
    public interface IUsersService
    {

        public Task<UserDto> GetProfile(ServerCallContext context);

        public Task<UserDto> EditProfile(EditProfileDto editProfileDto, ServerCallContext context);

        public Task<UserDto> GetByEmail(string email);
        
        public Task<RepeatedField<UserProgressDto>> GetUserProgress(ServerCallContext context);

        public Task SetUserProgress(UpdateUserProgressDto subjects, ServerCallContext context);
        
    }
}