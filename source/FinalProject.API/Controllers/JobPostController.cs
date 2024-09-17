using FinalProject.Domain.Reporistories;
using Microsoft.AspNetCore.Mvc;
using User.Module.Commands;
using User.Module.Services;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController(IJobRepository jobRepo, ILoginService loginService) : ControllerBase
    {
        private readonly IJobRepository _jobRepository = jobRepo;
        private readonly ILoginService _loginService = loginService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobRepository.GetAllAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginCommand command)
        {
            return Ok(await _loginService.Login(command.Email, command.Password));
        }
    }
}
