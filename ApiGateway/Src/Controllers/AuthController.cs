using ApiGateway.Src.DTOs.Auth;
using ApiGateway.Src.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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
            try
            {
                var loginResponse = await _authService.PostLogin(loginRequest);
                return Ok(loginResponse);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> PostRegister(RegisterStudentDto userRegister)
        {
            var loginResponse = await _authService.PostRegister(userRegister);
            return Ok(loginResponse);
        }

        [HttpPut("update-password")]
        public async Task<IActionResult> ChangePassword([FromBody] UpdatePasswordDto updatePassword)
        {
            try
            {
                await _authService.ChangePassword(updatePassword);
                return NoContent();
            }
            catch (HttpRequestException ex)
            {
                return StatusCode((int)HttpStatusCode.BadGateway, new { message = ex.Message });
            }
        }

    }
    
}