using Microsoft.AspNetCore.Mvc;

namespace Career.Src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase { }
}