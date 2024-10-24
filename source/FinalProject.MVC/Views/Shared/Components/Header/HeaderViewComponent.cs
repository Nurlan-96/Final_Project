using IdentityModule.Queries;
using IdentityModule.Response;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MVC.Views.Shared.Components.Header
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent(IUserQueries userQueries) : ViewComponent
    {
        private readonly IUserQueries _userQueries = userQueries;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var refreshToken = HttpContext.Request.Cookies["token"];
            ViewBag.UserResponse = null;

            if (string.IsNullOrEmpty(refreshToken))
            {
                return View();
            }

            var user = await _userQueries.FindByRefreshToken(refreshToken);
            if (user == null)
            {
                return View();
            }

            var userResponse = new UserResponse
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Id = user.Id,
                Fullname = user.Fullname
            };
            ViewBag.UserResponse = userResponse;

            return View();
        }
    }
}