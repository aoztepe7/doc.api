using doc.api.Handler;
using doc.api.Message;
using Microsoft.AspNetCore.Mvc;

namespace doc.api.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly LoginHandler _loginHandler;

        public AuthController(LoginHandler loginHandler)
        {
            _loginHandler = loginHandler;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            return Ok(await _loginHandler.execute(request));
        }
    }
}
