using ApiGateway.Src.DTOs.Auth;
using ApiGateway.Src.Clients.Interfaces;
using ApiGateway.Src.Services.Interfaces;

namespace ApiGateway.Src.Services
{
      public class AuthService : IAuthService
      {
            private readonly IAuthServiceClient _authServiceClient;

            public AuthService(IAuthServiceClient authServiceClient)
            {
                  _authServiceClient = authServiceClient;
            }

            public async Task<LoginResponseDto> PostLogin(LoginRequestDto loginRequest)
            {
                  return await _authServiceClient.PostLogin(loginRequest);
            }

            public async Task<LoginResponseDto> PostRegister(RegisterStudentDto registerRequest)
            {
                  return await _authServiceClient.PostRegister(registerRequest);
            }

            public async Task ChangePassword(UpdatePasswordDto changePasswordRequest, string token)
            {
                  await _authServiceClient.ChangePassword(changePasswordRequest, token);
            }
      }
}