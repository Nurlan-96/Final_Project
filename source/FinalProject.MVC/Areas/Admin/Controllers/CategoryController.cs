using Domain.Attributes;
using Domain.Entities.RoleAggergate;
using FinalProject.Infrastructure.DAL;
using Job.Module.Commands;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController(AppDbContext context, ICategoryService categoryService) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly ICategoryService _categoryService = categoryService;

        public async Task<IActionResult> Index()
        {
            return View(await _context.Categories.ToListAsync());
        }
        public async Task<IActionResult> GetbyId(int id)
        {
            return View(await _context.Categories.FirstOrDefaultAsync(x => x.Id == id));
        }

        [HttpPost("CreateCategory")]
        [AuthroizeRolesAttribute(Roles = RoleName.SuperAdmin)]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return Ok(await _categoryService.CreateCategory(command));
        }

        [HttpPatch]
        [AuthroizeRolesAttribute(Roles = RoleName.SuperAdmin)]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            return Ok(await _categoryService.UpdateCategory(command));
        }

        [HttpDelete]
        [AuthroizeRolesAttribute(Roles = RoleName.SuperAdmin)]
        public async Task<IActionResult> DeleteCategory([FromBody] int categoryId)
        {
            return Ok(await _categoryService.DeleteCategory(categoryId));
        }
    }
}
