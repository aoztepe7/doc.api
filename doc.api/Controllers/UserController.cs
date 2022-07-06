using doc.api.Handler;
using doc.api.Message;
using Microsoft.AspNetCore.Mvc;

namespace doc.api.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserCreateHandler _userCreateHandler;

        public UserController(UserCreateHandler userCreateHandler)
        {
            _userCreateHandler = userCreateHandler;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create(UserCreateRequest request)
        {
            return Ok(await _userCreateHandler.execute(request));
        }
    }
}
