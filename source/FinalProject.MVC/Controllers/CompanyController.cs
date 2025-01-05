using Company.Module.Commands;
using Company.Module.Services;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Queries;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Controllers
{
    public class CompanyController(IUserQueries userQueries, AppDbContext context, ICompanyService companyService) : Controller
    {
        private readonly IUserQueries _userQueries = userQueries;
        private readonly AppDbContext _context = context;
        private readonly ICompanyService _companyService = companyService;
        public async Task<IActionResult> Index()
        {
            var token = HttpContext.Request.Cookies["token"];
            var user = await _userQueries.FindByRefreshToken(token)
                ?? throw new EntityNotFoundException<UserEntity>();

            var company = await _context.Companies.FirstOrDefaultAsync(c => c.UserId == user.Id);
            if (company == null)
            {
                throw new EntityNotFoundException<CompanyEntity>();
            }

            var jobs = await _context.JobPosts
                .Where(j => j.CompanyId == company.Id)
                .ToListAsync();

            ViewBag.Jobs = jobs;
            return View(company);
        }


        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCompanyCommand command, string token)
        {
            token = HttpContext.Request.Cookies["token"];
            await _companyService.CreateCompany(command, token);
            return RedirectToAction("Index");
        }

        public IActionResult Update()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateCompanyCommand command, int id)
        {
            command.CompanyId = id;
            await _companyService.UpdateCompany(command);
            return RedirectToAction("Index", "Company");
        }
    }
}
