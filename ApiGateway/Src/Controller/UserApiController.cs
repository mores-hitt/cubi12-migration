using Microsoft.AspNetCore.Mvc;
using Shared.Library.Protos;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Authorization;
using ApiGateway.Src.Service.Interfaces;

namespace ApiGateway.Src.UserApiController{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("GetProfile")]
        public async Task<IActionResult> GetProfile()
        {
            var response = await _userService.GetProfile();
            return Ok(response);
        }
    }
}