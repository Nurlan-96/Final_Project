using Job.Module.Queries;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(ICategoryQuery categoryQuery) : ControllerBase
    {
        private readonly ICategoryQuery _categoryQuery = categoryQuery;

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] int page, int size)
        {
            return Ok(await _categoryQuery.GetAllCategories(page, size));
        }

        [HttpGet("id")]
        public async Task<IActionResult> GetById([FromForm] int id)
        {
            return Ok(await _categoryQuery.GetCategoryById(id));
        }
    }
}