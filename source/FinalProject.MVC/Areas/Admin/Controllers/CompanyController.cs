using Company.Module.Commands;
using Company.Module.Services;
using FinalProject.Infrastructure.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace FinalProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController(AppDbContext context, ICompanyService companyService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly ICompanyService _companyService = companyService;

        public async Task<IActionResult> Index()
        {
            return View(await _context.Companies.ToListAsync());
        }
        public async Task<IActionResult> GetbyId(int id)
        {
            return View( await _context.Companies.FirstOrDefaultAsync(x=>x.Id == id));
        }
        public async Task<IActionResult> ArchiveCompany(UpdateCompanyCommand command)
        {
            return Ok(await _companyService.ArchiveCompany(command));
        }
    }
}
