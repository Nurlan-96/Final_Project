using FinalProject.Domain.Reporistories;
using Job.Module.Command;
using Job.Module.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CategoryController(ICategoryRepository categoryRepo, ICategoryService categoryService) : ControllerBase
    {
        private readonly ICategoryRepository _categoryRepository = categoryRepo;
        private readonly ICategoryService _categoryService = categoryService;

        
        [HttpPost("Create")]
        [Authorize("Company")]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand command)
        {
            return Ok(await _categoryService.CreateCategory(command));
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryCommand command)
        {
            return Ok(await _categoryService.UpdateCategory(command));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteCategory([FromBody] int categoryId)
        {
            return Ok(await _categoryService.DeleteCategory(categoryId));
        }

    }
}