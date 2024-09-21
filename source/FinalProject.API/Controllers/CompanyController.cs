using FinalProject.Domain.Reporistories;
using Job.Module.Command;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyController(ICompanyRepository compRepo, ICompanyService companyService) : ControllerBase
    {
        private readonly ICompanyRepository _companyRepository = compRepo;
        private readonly ICompanyService _companyService = companyService;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _companyRepository.GetAllAsync());
        }
        [HttpGet("byid")]
        public async Task<IActionResult> GetById([FromQuery] int id)
        {
            return Ok(await _companyRepository.GetWhere(x => x.Id == id));
        }
        [HttpPost("Create")]
        public async Task<IActionResult> CreateCompany([FromForm] CreateCompanyCommand command)
        {
            return Ok(await _companyService.CreateCompany(command));
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCompany([FromForm] UpdateCompanyCommand command)
        {
            return Ok(await _companyService.UpdateCompany(command));
        }
        [HttpPatch]
        public async Task<IActionResult> ArchiveCompany([FromBody] UpdateCompanyCommand command)
        {
            return Ok(await _companyService.ArchiveCompany(command));
        }
    }
}
