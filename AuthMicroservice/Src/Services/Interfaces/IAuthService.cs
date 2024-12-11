using Auth.Src.DTOs.Auth;

namespace Auth.Src.Services.Interfaces
{
    public interface IAuthService
    {
        public Task<LoginResponseDto> Login(LoginRequestDto loginRequestDto);

        public Task<LoginResponseDto> Register(RegisterStudentDto registerStudentDto);

        public string GetUserEmailInToken();
        public string GetUserRoleInToken();

        public Task UpdatePassword(UpdatePasswordDto updatePasswordDto);

    }
}