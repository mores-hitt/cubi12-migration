using MassTransit;
using Shared.Library.Messages;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]

public class MessagesController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public MessagesController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("user-created")]
    public async Task<IActionResult> UserCreated(UserCreatedMessage message)
    {
        await _publishEndpoint.Publish(message);
        return Ok();
    }

    [HttpPost("update-password")]
    public async Task<IActionResult> UpdatePassword(UpdatePasswordMessage message)
    {
        await _publishEndpoint.Publish(message);
        return Ok();
    }
}