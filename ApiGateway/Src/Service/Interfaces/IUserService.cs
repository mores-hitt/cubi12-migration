using Grpc.Core;
using Google.Protobuf.Collections;
using Shared.Library.Protos;

namespace ApiGateway.Src.Service.Interfaces
{
    public interface IUserService
    {
        public Task<UserDto> GetProfile();
    }
}