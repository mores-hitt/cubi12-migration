using System.Runtime.Versioning;
using Microsoft.AspNetCore.Mvc;
using ApiGateway.Src.DTOs.Auth;

namespace ApiGateway.Src.Clients.Interfaces
{
    public interface IAuthServiceClient
    {
        public Task<LoginResponseDto> PostLogin(LoginRequestDto loginRequest);

        public Task<LoginResponseDto> PostRegister(RegisterStudentDto registerRequest);

        public Task ChangePassword(UpdatePasswordDto changePasswordRequest, string token);

        public Task<bool> ValidateToken(string token);
    }
}