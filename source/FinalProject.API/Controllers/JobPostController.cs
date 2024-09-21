using FinalProject.Domain.Reporistories;
using Job.Module.Command;
using Job.Module.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController(IJobRepository jobRepo, IJobService jobService): ControllerBase
    {
        private readonly IJobRepository _jobRepository = jobRepo;
        private readonly IJobService _jobService = jobService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobRepository.GetAllAsync());
        }
        [HttpPost("Create")]
        public async Task<IActionResult> PostJob([FromBody] CreateJobCommand command)
        {
            return Ok(await _jobService.CreateJobPost(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateJob([FromBody] UpdateJobCommand command)
        {
            return Ok(await _jobService.UpdateJobPost(command));
        }
        [HttpPatch]
        public async Task<IActionResult> ArchiveJob([FromBody] UpdateJobCommand command)
        {
            return Ok(await _jobService.ArchiveJobPost(command));
        }
    }
}
