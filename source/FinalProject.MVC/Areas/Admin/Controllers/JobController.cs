using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Identity.Module.Auth;
using Job.Module;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Admin.Controllers
{
    [Area("Admin")]
    public class JobController(ILogger<JobController> logger, AppDbContext context, IJobQuery jobQuery, IUserManager userManager, IUserRepository userRepo, IJobRepository jobRepo, IJobService jobService) : Controller
    {
        private readonly ILogger<JobController> _logger = logger;
        private readonly AppDbContext _context = context;
        private readonly IJobQuery _jobQuery = jobQuery;
        private readonly IJobRepository _jobRepo = jobRepo;
        private readonly IUserRepository _userRepository = userRepo;
        private readonly IUserManager _userManager = userManager;
        private readonly IJobService _jobService = jobService;

        public async Task<IActionResult> Detail(int id)
        {
            var data = await _context.JobPosts.Include(j=>j.Category).Include(j=>j.Company).FirstOrDefaultAsync(j => j.Id == id);
            return View(data);
        }
        public async Task<IActionResult> ArchiveJob([FromForm] UpdateJobCommand command)
        {
            return Ok(await _jobService.ArchiveJobPost(command));
        }

    }
}
