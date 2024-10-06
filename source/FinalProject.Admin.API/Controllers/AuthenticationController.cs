using FinalProject.Domain.Reporistories;
using Job.Module.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using User.Module.Commands;

namespace FinalProject.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(User.Module.Services.IAuthorizationService loginService) : ControllerBase
    {
        private readonly User.Module.Services.IAuthorizationService _authorizationService = loginService;

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterCommand command, CancellationToken cancellationToken)
        {
            return Ok(await _authorizationService.Register(command, cancellationToken));
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return Ok(await _authorizationService.Login(command));
        }
    }
}
