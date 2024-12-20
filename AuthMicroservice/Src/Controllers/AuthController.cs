using Microsoft.AspNetCore.Mvc;
using Auth.Src.Services.Interfaces;
using Auth.Src.DTOs.Auth;
using Microsoft.AspNetCore.Authorization;
using Auth.Src.Dtos;

namespace Auth.Src.Controllers

{   [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDto>> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var response = await _authService.Login(loginRequestDto);
            return Ok(response);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDto>> Register([FromBody] RegisterStudentDto registerStudentDto)
        {
            var loginResponse = await _authService.Register(registerStudentDto);
            return CreatedAtAction(nameof(Login), new { id = loginResponse.Id }, loginResponse);
        }

        [HttpPut("update-password")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordDto updatePasswordDto)
        {
            await _authService.UpdatePassword(updatePasswordDto);
            return NoContent();
        }

        [HttpPost("validate-token")]
        public async Task<ActionResult> ValidateToken([FromBody] ValidateTokenDto token)
        {
            var isValid = await _authService.ValidateToken(token.Token);
            if ( isValid)
            {
                return Ok(new { message = "Token is valid" });
            }
            else
            {
                return Unauthorized(new { message = "Token is invalid" });
            }
        }
    }
}
