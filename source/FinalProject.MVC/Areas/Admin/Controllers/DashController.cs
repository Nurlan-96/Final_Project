using FinalProject.Infrastructure.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.JobPosts.ToListAsync());
        }
    }
}
