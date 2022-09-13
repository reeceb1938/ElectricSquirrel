using AccessControl.Core.Commands;
using AccessControl.Core.Interfaces;
using AccessControl.Core.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElectricSquirrel.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccessControlController : ControllerBase
    {
        private readonly IAccessControlService _accessControlService;

        public AccessControlController(IAccessControlService accessControlService)
        {
            _accessControlService = accessControlService;
        }

        [HttpPost("Login")]
        public async Task<LoginResponse> Login(Login command)
        {
            var result = await _accessControlService.LoginAsync(command);
            return result;
        }

        [HttpGet("Logout")]
        public string Logout()
        {
            return "Goodbye";
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(Register command)
        {
            var result = await _accessControlService.RegisterAsync(command);

            if (result.IsSuccess)
            {
                return Ok();
            }

            return StatusCode(500, result.Message);
        }
    }
}
