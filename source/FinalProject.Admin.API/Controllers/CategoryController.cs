using Domain.Attributes;
using Domain.Entities.RoleAggergate;
using Job.Module.Commands;
using Job.Module.Queries;
using Job.Module.Service;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Admin.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public partial class CategoryController(ICategoryService categoryService, ICategoryQuery categoryQuery) : ControllerBase
    {
        private readonly ICategoryService _categoryService = categoryService;
        private readonly ICategoryQuery _categoryQuery = categoryQuery;

        [HttpPost("Create")]
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