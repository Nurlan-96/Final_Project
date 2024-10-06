using FinalProject.Domain.Reporistories;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;
using User.Module.Commands;
using User.Module.Services;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController(IJobRepository jobRepo, IAuthorizationService loginService, IJobService jobService) : ControllerBase
    {
        private readonly IJobRepository _jobRepository = jobRepo;
        private readonly IJobService _jobService = jobService;
        private readonly IAuthorizationService _authorizationService = loginService;

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
   
