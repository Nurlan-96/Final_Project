using FinalProject.Domain.Reporistories;
using FinalProject.Infrastructure.DAL;
using Microsoft.AspNetCore.Mvc;
using User.Module.Services;

namespace FinalProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController(AppDbContext context, IUserService userService, IUserRepository userRepository) : Controller
    {
        private readonly AppDbContext _context = context;
        private readonly IUserService _userService = userService;
        private readonly IUserRepository _userRepository = userRepository;

        public async Task<IActionResult> Index()
        {
            return View(await _userRepository.GetAllAsync());
        } 
        public async Task<IActionResult> Detail(int id)
        {
            return View(await _userRepository.GetWhere(r=>r.Id==id));
        }
        //public async Task<IActionResult> Ban ([FromForm]UpdateUserCommand command)
        //{
        //    return Ok(await _userService.BanUser(command));
        //}
    }
}
