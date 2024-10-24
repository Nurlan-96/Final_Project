using Company.Module.Services;
using FinalProject.Application.Attributes;
using FinalProject.Domain.Constants;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.DAL;
using FinalProject.MVC.ViewModels;
using Identity.Module.Auth;
using IdentityModule.Queries;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace FinalProject.MVC.Controllers
{
    public class HomeController(AppDbContext context, 
        IJobService jobService, 
        IUserQueries userQueries,
        ICategoryService categoryService, 
        ICompanyService companyService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly IJobService _jobService = jobService;
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ICompanyService _companyService = companyService;
        private readonly IUserQueries _userQueries = userQueries;

        public async Task<IActionResult> Index()
        {
            HomeVM data = new();
            UserEntity? user = new();
            var token = Request.Cookies["token"];
            if (!string.IsNullOrEmpty(token)) 
            {
                user = await _userQueries.FindByRefreshToken(token);
            }
            else
                return RedirectToAction("IndexWithoutUser","Home");
            try
            {
                data.User = new();
                #region User
                data.User.Fullname = user.Fullname;
                data.User.PhoneNumber = user.PhoneNumber;
                data.User.Email = user.Email;
                data.User.CreatedDate = user.CreatedDate;
                #endregion
                data.JobPosts = [.. _context.JobPosts
                        .AsNoTracking()
                        .Include(j => j.Category)
                        .Include(j => j.Company)];
                data.Companies = [.. _context.Companies
                        .AsNoTracking()
                        .Include(c => c.JobPosts)];
                data.Categories = [.. _context.Categories
                        .AsNoTracking()
                        .Include(c => c.JobPosts)];
                data.Cities = Enum.GetValues(typeof(CityEnum)).Cast<CityEnum>();

            }
            catch (Exception)
            {
                ForceLogOut();
            }
            return View(data);
        }


        public IActionResult IndexWithoutUser()
        {
            var homeVM = new HomeVM()
            {
                JobPosts = [.. _context.JobPosts
                    .AsNoTracking()
                    .Include(j => j.Category)
                    .Include(j => j.Company)],
                Companies = [.. _context.Companies
                    .AsNoTracking()
                    .Include(c => c.JobPosts)],
                Categories = [.. _context.Categories
                    .AsNoTracking()
                    .Include(c => c.JobPosts)],
                Cities = Enum.GetValues(typeof(CityEnum)).Cast<CityEnum>()
            };
            return View(homeVM);
        }

        [HttpGet]
        public IActionResult SearchJobs(string query)
        {
            var jobs = string.IsNullOrEmpty(query)
                ? _context.JobPosts.ToList()
                : _jobService.SearchJobs(query);
            return PartialView("_JobResults", jobs);
        }


        [HttpGet]
        public IActionResult SearchCategories(string query)
        {
            var categories = string.IsNullOrEmpty(query)
                ? _context.Categories.ToList()
                : _categoryService.SearchCategories(query);
            return PartialView("_CategoryResults", categories);
        }

        [HttpGet]
        public IActionResult SearchCompanies(string query)
        {
            var companies = string.IsNullOrEmpty(query)
                ? _context.Companies.ToList()
                : _companyService.SearchCompanies(query);
            return PartialView("_CompanyResults", companies);
        }

        private IActionResult ForceLogOut()
        {
            Response.Cookies.Delete("token");
            return RedirectToAction("login", "admin"); //was login admin
        }
    } 
}