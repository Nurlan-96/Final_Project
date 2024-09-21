using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.API.Controllers
{
    public partial class CategoryController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _categoryRepository.GetAllAsync());
        }

        [HttpGet("byid")]
        public async Task<IActionResult> GetById([FromBody] int id)
        {
            return Ok(await _categoryRepository.GetWhere(x => x.Id == id));
        }
    }
}