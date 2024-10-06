using IdentityModule.Queries;
using IdentityModule.Response;
using Microsoft.AspNetCore.Mvc;

namespace FinalProject.MVC.Views.Shared.Components.Header
{
    [ViewComponent(Name = "Header")]
    public class HeaderViewComponent(IUserQueries userQueries) : ViewComponent
    {
        IUserQueries _userQueries = userQueries;

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var refreshToken = HttpContext.Request.Cookies["refreshToken"];
            if (string.IsNullOrEmpty(refreshToken))
            {
                return View(); // Return the view without user info if there's no refresh token
            }

            var user = await _userQueries.FindByRefreshToken(refreshToken);
            if (user == null)
            {
                return View(); // Return the view without user info if user is not found
            }

            var userResponse = new UserResponse
            {
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
                Id = user.Id,
                Fullname = user.Fullname // Assign FullName from the retrieved user
            };

            return View(userResponse);
        }
    }
}
