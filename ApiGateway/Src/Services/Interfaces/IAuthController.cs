using ApiGateway.Src.DTOs.Auth;
namespace ApiGateway.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> PostLogin(LoginRequestDto loginRequest);

        public Task<LoginResponseDto> PostRegister(RegisterStudentDto registerRequest);

        public Task ChangePassword(UpdatePasswordDto changePasswordRequest, string token);
    }
}