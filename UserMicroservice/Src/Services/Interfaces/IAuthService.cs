using Grpc.Core;

namespace user_microservice.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public string GetUserEmailInToken(ServerCallContext context);

        public string CreateToken(string email, string role);

    }
}