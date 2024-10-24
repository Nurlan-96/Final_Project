using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Infrastructure.Identity;
using Job.Module;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MVC.Controllers
{
    public class CVController(AppDbContext context, ICVService cvService, ICVQuery cvQuery, IClaimsManager claimsManager, ICVRepository cvRepository, ICVJobService cvJobService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly ICVService _cvService = cvService;
        private readonly ICVQuery _cvQuery = cvQuery;
        private readonly IClaimsManager _claimsManager = claimsManager;
        private readonly ICVRepository _cvRepo = cvRepository;
        private readonly ICVJobService _cvJobService = cvJobService;

        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Request.Cookies["token"];
            return View(await _cvQuery.GetCVByUserId(token));
        }


        [HttpGet("Create")]
        public  IActionResult Create()
        {
            return View();
        }

        [HttpPost("Create")]    
        public async Task<IActionResult> Create(CreateCVCommand command)
        {
            var token = HttpContext.Request.Cookies["token"];
            await _cvService.CreateCV(command, token);
            return RedirectToAction("Index", "UserProfile");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPut("UpdateCV")]
        public async Task<IActionResult> Update(UpdateCVCommand command)
        {
            await _cvService.UpdateCV(command);
            return RedirectToAction("Index", "CV");
        }

        public IActionResult CreateCVJob()
        {
            return View();
        }


        [HttpPost]
        public IActionResult CreateCVJob(CreateCVJobCommand command)
        {
            var token = HttpContext.Request.Cookies["token"];

            _cvJobService.CreateCVJob(command, token);
            return RedirectToAction("Index", "CV");
        }
    }
}
