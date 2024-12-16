using Microsoft.AspNetCore.Mvc;
using Shared.Library.Protos;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using ApiGateway.Src.Services.Interfaces;
using ApiGateway.Src.DTOs.User;

namespace ApiGateway.Src.UserApiController
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("profile")]
        public async Task<ActionResult<UserDto>> GetProfile()
        {
            var response = await _userService.GetProfile();
            return Ok(response);
        }

        [HttpGet("my-progress")]
        public async Task<ActionResult<List<UserProgressDto>>> GetUserProgress()
        {
            var response = await _userService.GetUserProgress();
            return Ok(response);
        }

        [HttpPatch("my-progress")]
        public async Task<IActionResult> SetUserProgress(ApiGateway.Src.DTOs.User.UpdateUserProgressDto updateUserProgress)
        {
            await _userService.SetUserProgress(updateUserProgress);
            return Ok();
        }

        [HttpPatch("update-profile")]
        public async Task<ActionResult<UserDto>> EditProfile(UpdateUserProfileDto user)
        {
            var userUpdate = await _userService.EditProfile(user);
            return Ok(userUpdate);
        }
    }
}