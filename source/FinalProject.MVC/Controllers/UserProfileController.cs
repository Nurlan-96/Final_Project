using AutoMapper;
using FinalProject.Domain.Entities.RoleAggregate;
using FinalProject.MVC.ViewModels;
using IdentityModule.Queries;
using IdentityModule.Response;
using Microsoft.AspNetCore.Mvc;
using User.Module.Commands;
using User.Module.Services;

namespace FinalProject.MVC.Controllers
{
    public class UserProfileController(IUserQueries userQuery, IUserService userService, IMapper mapper) : Controller
    {
        private readonly IUserQueries _userQuery = userQuery;
        private readonly IUserService _userService = userService;
        private readonly IMapper _mapper = mapper;

        public async Task<IActionResult> Index()
        {
            var refreshToken = HttpContext.Request.Cookies["token"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return RedirectToAction("login", "authentication");
            }

            var user = await _userQuery.FindByRefreshToken(refreshToken);

            if (user == null)
            {
                return RedirectToAction("login", "authentication");
            }

            var data = new HomeVM
            {
                User = new()
            };

            data.User = _mapper.Map<UserResponse>(user);
            data.User.CVEntityId = user.CVEntityId;

            return View(data);
        }

        public async Task<IActionResult> EditUser()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(UpdateUserCommand command)
        {
            var refreshToken = HttpContext.Request.Cookies["token"];
            if (!ModelState.IsValid)
            {
                return View(command);
            }

            await _userService.EditUser(command, refreshToken);
            return RedirectToAction("Index");
        }

    }
}
