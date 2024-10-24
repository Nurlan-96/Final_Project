using FinalProject.Domain.Reporistories;
using Job.Module;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVController(ICVRepository cvRepo, ICVService cvService, ICVQuery cvQuery) : ControllerBase
    {
        private readonly ICVRepository _cvRepository = cvRepo;
        private readonly ICVService _cvService = cvService;
        private readonly ICVQuery _cvQuery = cvQuery;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, int size)
        {
            return Ok(await _cvQuery.GetAllCV(page, size));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById(string token)
        {
            return Ok(await _cvQuery.GetCVByUserId(token));
        }

        [HttpPost("Create")]
        public async Task<IActionResult> CreateCV([FromBody] CreateCVCommand command, string token)
        {
            return Ok(await _cvService.CreateCV(command, token));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCV([FromBody] UpdateCVCommand command)
        {
            return Ok(await _cvService.UpdateCV(command));
        } 
        
        [HttpDelete]
        public async Task<IActionResult> DeleteCV(int cvId)
        {
            return Ok(await _cvService.DeleteCV(cvId));
        }
    }
}
