using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ReportController(AppDbContext context, IReportService reportService, IReportRepository reportRepository) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly IReportService _reportService = reportService;
        private readonly IReportRepository _reportRepository = reportRepository;

        public async Task<IActionResult> Index()
        {
            return View(await _reportRepository.GetAllAsync());
        } 
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _reportRepository.GetWhere(r=>r.Id==id));
        }
        public async Task<IActionResult> Archive (UpdateReportCommand command)
        {
            return Ok(await _reportService.ArchiveReport(command));
        }
    }
}
