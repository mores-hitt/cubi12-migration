using ApiGateway.Src.DTOs.Auth;
using ApiGateway.Src.Clients.Interfaces;
using ApiGateway.Src.Services.Interfaces;

namespace ApiGateway.Src.Services
{
      public class AuthService : IAuthService
      {
            private readonly IAuthServiceClient _authServiceClient;
            private readonly IHttpContextAccessor _ctxAccessor;

            public AuthService(IAuthServiceClient authServiceClient, IHttpContextAccessor ctxAccessor)
            {
                  _authServiceClient = authServiceClient;
                   _ctxAccessor = ctxAccessor;
            }

            public async Task<LoginResponseDto> PostLogin(LoginRequestDto loginRequest)
            {
                  return await _authServiceClient.PostLogin(loginRequest);
            }

            public async Task<LoginResponseDto> PostRegister(RegisterStudentDto registerRequest)
            {
                  return await _authServiceClient.PostRegister(registerRequest);
            }

            public async Task ChangePassword(UpdatePasswordDto changePasswordRequest)
            {
                  var token = ExtractToken();
                  try
                  {
                        await _authServiceClient.ChangePassword(changePasswordRequest, token);
                  }
                  catch (HttpRequestException ex)
                  {
                        throw new HttpRequestException($"Error changing password: {ex.Message}", ex);
                  }
            }

            public string ExtractToken()
            {
                  var token = _ctxAccessor.HttpContext.Request.Headers["Authorization"].ToString()?.Split(" ").Last();
                  if (string.IsNullOrEmpty(token))
                  {
                        throw new UnauthorizedAccessException("Token not provided");
                  }
                  return token;
            }
      }
}