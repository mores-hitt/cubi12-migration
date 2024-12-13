using ApiGateway.Src.DTOs.Auth;
using ApiGateway.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGateway.Src.Controllers
{
    public class AuthController : BaseApiController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> PostLogin(LoginRequestDto loginRequest)
        {
            var loginResponse = await _authService.PostLogin(loginRequest);
            return Ok(loginResponse);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> PostRegister(RegisterStudentDto userRegister)
        {
            var loginResponse = await _authService.PostRegister(userRegister);
            return Ok(loginResponse);
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordDto updatePassword, [FromHeader(Name = "Authorization")] string authorization)
        {
            var token = authorization?.Split(" ").Last();
            if (string.IsNullOrEmpty(token))
            {
                return Unauthorized("Token no proporcionado");
            }
            await _authService.ChangePassword(updatePassword, token);
            return NoContent();
        }

    }
    
}