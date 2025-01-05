using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Identity.Module.Auth;
using IdentityModule.Queries;
using Job.Module;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Controllers
{
    public class JobController(ILogger<JobController> logger, AppDbContext context, IJobQuery jobQuery, IUserManager userManager, IUserRepository userRepo, IJobRepository jobRepo, IJobService jobService, IUserQueries userQueries) : Controller
    {
        private readonly ILogger<JobController> _logger = logger;
        private readonly AppDbContext _context = context;
        private readonly IJobQuery _jobQuery = jobQuery;
        private readonly IJobRepository _jobRepo = jobRepo;
        private readonly IUserRepository _userRepository = userRepo;
        private readonly IUserManager _userManager = userManager;
        private readonly IJobService _jobService = jobService;
        private readonly IUserQueries _userQueries = userQueries;

        public async Task<IActionResult> Index(int id)
        {
            var data = await _context.JobPosts.Include(j=>j.Category).Include(j=>j.Company).FirstOrDefaultAsync(j => j.Id == id);
            return View(data);
        }
        public async Task<IActionResult> Apply(int jobId)
        {
            var refreshToken = HttpContext.Request.Cookies["token"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return RedirectToAction("login", "authentication");
            }

            var user = await _userQueries.FindByRefreshToken(refreshToken);

            var job = await _jobRepo.GetAsync(x => x.Id == jobId);

            if (job == null || user == null)
            {
                return NotFound("Job or User not found");
            }

            var userAppliedJob = await _context.UserAppliedJobs
                .FirstOrDefaultAsync(uaj => uaj.UserId == user.Id);

            if (userAppliedJob == null)
            {
                userAppliedJob = new UserAppliedJob { UserId = user.Id, User = user };
                userAppliedJob.AddJobPost(job);
                _context.UserAppliedJobs.Add(userAppliedJob);
            }
            else if (!userAppliedJob.JobPosts.Any(j => j.Id == jobId))
            {
                userAppliedJob.AddJobPost(job);
            }
            else
            {
                return BadRequest("Job already applied for.");
            }

            await _context.SaveChangesAsync();
            return Ok("Job application successful.");
        }

        public IActionResult CreateJob(int id)
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View();
        }

        [HttpPost("job/createjob")]
        public async Task<IActionResult> CreateJob(CreateJobCommand command)
        {
            var user = await _userQueries.FindByRefreshToken(HttpContext.Request.Cookies["token"]);
            var company = _context.Companies.FirstOrDefault(x => x.UserId == user.Id);
            command.CompanyId = company.Id;
            ViewBag.Categories = await _context.Categories.ToListAsync();
            await _jobService.CreateJobPost(command);
            return RedirectToAction("Index", "Company");
        }
    }
}
