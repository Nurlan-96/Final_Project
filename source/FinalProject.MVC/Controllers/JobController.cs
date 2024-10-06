using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Identity.Module.Auth;
using IdentityModule.Queries;
using Job.Module;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Controllers
{
    public class JobController(ILogger<JobController> logger, AppDbContext context, IJobQuery jobQuery, IUserManager userManager, IUserRepository userRepo, IJobRepository jobRepo) : Controller
    {
        private readonly ILogger<JobController> _logger = logger;
        private readonly AppDbContext _context = context;
        private readonly IJobQuery _jobQuery = jobQuery;
        private readonly IJobRepository _jobRepo = jobRepo;
        private readonly IUserRepository _userRepository = userRepo;
        private readonly IUserManager _userManager = userManager;

        public async Task<IActionResult> Index(int id)
        {
            var data = await _context.JobPosts.Include(j=>j.Category).Include(j=>j.Company).FirstOrDefaultAsync(j => j.Id == id);
            return View(data);
        }
        public async Task<IActionResult> Apply(int jobId)
        {
            var userId = _userManager.GetCurrentUserId();
            var job = await _jobRepo.GetAsync(x => x.Id == jobId);
            var user = await _userRepository.GetAsync(x=> x.Id == userId);

            if (job == null || user == null)
            {
                return NotFound("Job or User not found");
            }

            var userAppliedJob = await _context.UserAppliedJobs
                .FirstOrDefaultAsync(uaj => uaj.UserId == userId);

            if (userAppliedJob == null)
            {
                userAppliedJob = new UserAppliedJob { UserId = userId, User = user };
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
    }
}
