using FinalProject.Domain.Reporistories;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController(IReportRepository reportRepo, IReportService reportService) : ControllerBase
    {
        private readonly IReportRepository _reportRepository = reportRepo;
        private readonly IReportService _reportService = reportService;

        [HttpPost("Create")]
        public async Task<IActionResult> CreateReport([FromForm] CreateReportCommand command)
        {
            return Ok(await _reportService.CreateReport(command));
        }
    }
}
