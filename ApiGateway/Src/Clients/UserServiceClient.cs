using System.Threading.Tasks;
using Grpc.Net.Client;
using Shared.Library.Protos;
using ApiGateway.Src.Clients.Interfaces;
using System.Threading.Channels;
using Grpc.Core;

namespace ApiGateway.Src.Clients
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly UserGrpc.UserGrpcClient _client;

        public UserServiceClient()
        {
            _client = new UserGrpc.UserGrpcClient(GrpcChannel.ForAddress("http://localhost:5375"));
            
        }

        public async Task<UserDto> GetUserAsync(string token)
        {
            var headers = new Metadata
                {
                    { "Authorization", $"Bearer {token}" }
                };


                
            return await _client.GetProfileAsync(new Empty(), headers);
        }

        public async Task<GetUserProgressResponse> GetUserProgressAsync(string token)
        {
            var headers = new Metadata
                {
                    { "Authorization", $"Bearer {token}" }
                };
            return await _client.GetUserProgressAsync(new Empty(), headers);
        }

        public async Task SetUserProgressAsync(UpdateUserProgressDto updateUserProgress, string token)
        {
             try
            {
                var headers = new Metadata
                {
                    { "Authorization", $"Bearer {token}" }
                };
                await _client.SetUserProgressAsync(updateUserProgress, headers);
            }
            catch (RpcException ex)
            {
                throw new Exception("Error al actualizar el progreso del usuario", ex);
            }
        }
        
        public async Task<UserDto> EditProfile(EditProfileDto user, string token)
        {
             try
            {
                var headers = new Metadata
                {
                    { "Authorization", $"Bearer {token}" }
                };

                return await _client.EditProfileAsync(user, headers);
            }
            catch (RpcException ex)
            {
                throw new Exception("Error al editar al usuario", ex);
            }
        }
    }
}