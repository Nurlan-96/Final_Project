using Company.Module.Commands;
using Company.Module.Services;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Queries;
using Microsoft.AspNetCore.Mvc;

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
            var company = _context.Companies.FirstOrDefault(c => c.UserId == user.Id);
            return View(company);
        }

        public async Task<IActionResult> Create(CreateCompanyCommand command, string token)
        {
            var user = await _userQueries.FindByRefreshToken(token)
            ?? throw new EntityNotFoundException<UserEntity>();
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
