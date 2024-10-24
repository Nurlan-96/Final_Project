using FinalProject.Domain.Reporistories;
using Job.Module;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVJobController(ICVJobRepository jobRepo, ICVJobService jobService, ICVJobQuery jobQuery) : ControllerBase
    {
        private readonly ICVJobRepository _jobRepository = jobRepo;
        private readonly ICVJobService _jobService = jobService;
        private readonly ICVJobQuery _jobQuery = jobQuery;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, int size)
        {
            return Ok(await _jobQuery.GetAllCVJobs(page, size));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return Ok(await _jobQuery.GetCVJobById(id));
        }        

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCVJob([FromForm] CreateCVJobCommand command, string token)
        {
            return Ok(await _jobService.CreateCVJob(command, token));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCVJob([FromForm] UpdateCVJobCommand command)
        {
            return Ok(await _jobService.UpdateCVJob(command));
        }
    }
}
