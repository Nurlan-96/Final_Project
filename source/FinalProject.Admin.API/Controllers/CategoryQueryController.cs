using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.Admin.API.Controllers
{
    public partial class CategoryController
    {
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