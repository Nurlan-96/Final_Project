using FinalProject.Domain.Reporistories;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPostController(IJobRepository jobRepo) : ControllerBase
    {
        private readonly IJobRepository _jobRepository = jobRepo;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _jobRepository.GetAllAsync());
        }
    }
}
