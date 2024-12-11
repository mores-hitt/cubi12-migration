using Grpc.Core;
using Microsoft.AspNetCore.Authorization;
using Shared.Library.Protos;
using Microsoft.AspNetCore.Http;
using Grpc.Net.Client;
using ApiGateway.Interfaces;

namespace ApiGateway.Src.Service{
    public class UserService : IUserService{


        public UserService()
        {
        }

        public async Task<UserDto> GetProfile()
        {
            using var channel = GrpcChannel.ForAddress("http://localhost:5253");
            var client = new UserGrpc.UserGrpcClient(channel);
            var reply = await client.GetProfileAsync(new Empty());
            return reply;
        }
    }
}