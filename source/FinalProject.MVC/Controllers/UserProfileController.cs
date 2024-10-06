using AutoMapper;
using IdentityModule.Queries;
using IdentityModule.Response;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MVC.Controllers
{
    public class UserProfileController(IUserQueries userQuery, IMapper mapper) : Controller
    {
        private readonly IUserQueries _userQuery = userQuery;

        public async Task<IActionResult> Index()
        {
            var refreshToken = HttpContext.Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return RedirectToAction("login", "authentication");
            }

            var user = await _userQuery.FindByRefreshToken(refreshToken);

            if (user == null)
            {
                return RedirectToAction("login", "authentication");
            }

            var mapped = new UserResponse
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Id = user.Id
            };

            return View(mapped);
        }
    }
}
