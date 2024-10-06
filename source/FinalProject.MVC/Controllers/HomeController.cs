using FinalProject.Domain.Constants;
using FinalProject.Infrastructure.DAL;
using FinalProject.MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;
        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {   
            var homeVM = new HomeVM()
            {
                JobPosts = _context.JobPosts.AsNoTracking().Include(j => j.Category).Include(j => j.Company).ToList(),
                Companies = _context.Companies.AsNoTracking().Include(x => x.JobPosts).ToList(),
                Categories = _context.Categories.AsNoTracking().Include(x => x.JobPosts).ToList(),
                Cities = Enum.GetValues(typeof(CityEnum)).Cast<CityEnum>()
            };
            return View(homeVM);
        }
    }
}