using IdentityModule.Queries;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MVC.Controllers
{
    public class ReportController(IReportService reportService, IUserQueries userQueries) : Controller
    {
        private readonly IReportService _reportService = reportService;
        private readonly IUserQueries _userQueries = userQueries;

        public IActionResult CreateReport()
        {
            return View();
        }   
        public async Task<IActionResult> CreateReport(CreateReportCommand command)
        {
            var user = await _userQueries.FindByRefreshToken(HttpContext.Request.Cookies["token"]);
            command.UserId = user.Id;
            _reportService.CreateReport(command);
            return Ok();
        }
    }
}
