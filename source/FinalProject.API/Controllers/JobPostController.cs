using FinalProject.Domain.Reporistories;
using Job.Module;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController(IJobRepository jobRepo, IJobService jobService, IJobQuery jobQuery) : ControllerBase
    {
        private readonly IJobRepository _jobRepository = jobRepo;
        private readonly IJobService _jobService = jobService;
        private readonly IJobQuery _jobQuery = jobQuery;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, int size)
        {
            return Ok(await _jobQuery.GetAllJobs(page, size));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return Ok(await _jobQuery.GetJobById(id));
        }        
        [HttpGet("category")]
        public async Task<IActionResult> GetByCategory([FromForm] int id)
        {
            return Ok(await _jobQuery.GetJobByCategory(id));
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
