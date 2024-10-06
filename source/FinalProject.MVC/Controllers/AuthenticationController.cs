using Microsoft.AspNetCore.Mvc;
using User.Module.Commands;
using User.Module.Services;

namespace FinalProject.MVC.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly ILogger<AuthenticationController> _logger;
        private readonly IAuthorizationService _authService;
        private readonly IUserService _userService;

        public AuthenticationController(ILogger<AuthenticationController> logger, IAuthorizationService service, IUserService userService)
        {
            _authService = service;
            _userService = userService;
            _logger = logger;
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            Identity.Module.Response.JWTResponse tokenResponse = await _authService.Login(command);

            // Create cookie options for the JWT token
            var jwtCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = tokenResponse.ExpiresAt // Set expiry to JWT token expiration
            };

            // Add JWT token to the cookies
            HttpContext.Response.Cookies.Append("Bearer", tokenResponse.Token, jwtCookieOptions);

            // Create cookie options for the Refresh Token
            var refreshTokenCookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTime.UtcNow.AddDays(30) // Set expiry to match Refresh Token duration
            };

            // Add Refresh Token to the cookies
            HttpContext.Response.Cookies.Append("refreshToken", tokenResponse.RefreshToken, refreshTokenCookieOptions);

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancelToken)
        {
            await _authService.Register(command, cancelToken);
            return RedirectToAction("Index", "Home");
        }
    }
}