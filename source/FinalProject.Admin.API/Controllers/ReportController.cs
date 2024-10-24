using FinalProject.Domain.Reporistories;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportRepository reportRepo, IReportService reportService) : ControllerBase
    {
        private readonly IReportRepository _reportRepository = reportRepo;
        private readonly IReportService _reportService = reportService;

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetReports()
        {
            return Ok(_reportRepository.GetAllAsync());
        }
        [HttpGet("Get")]
        public async Task<IActionResult> GetReport(int reportId)
        {
            return Ok(_reportRepository.GetWhere(x => x.Id == reportId));
        }
        [HttpPatch]
        public async Task<IActionResult> ArchiveReport([FromForm] UpdateReportCommand command)
        {
            return Ok(await _reportService.ArchiveReport(command));
        }
    }
}
