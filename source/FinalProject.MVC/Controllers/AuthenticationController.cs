using CryptoHelper;
using FinalProject.Application.Attributes;
using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.DAL;
using IdentityModule.Queries;
using Microsoft.AspNetCore.Mvc;
using User.Module.Commands;
using User.Module.Services;

namespace FinalProject.MVC.Controllers
{
    public class AuthenticationController(ILogger<AuthenticationController> logger,
        IUserQueries userQueries,
        AppDbContext context, IAuthorizationService authorizationService) : Controller
    {
        private readonly ILogger<AuthenticationController> _logger = logger;
        private readonly IUserQueries _userQueries = userQueries;
        private readonly AppDbContext _context = context;
        private readonly IAuthorizationService _authorizationService = authorizationService;

        public async Task<IActionResult> Login()
        {
            Response.HttpContext.Request.Cookies.TryGetValue("token", out string token);
            if (!string.IsNullOrEmpty(token))
                return RedirectToAction("Index", "UserProfile");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var user = await _userQueries.FindAsync(command.Email);
                if (user != null && Crypto.VerifyHashedPassword(user.PasswordHash, command.Password))
                {
                    user.RefreshToken = Guid.NewGuid().ToString();
                    _context.SaveChanges();
                    Response.Cookies.Append("token", user.RefreshToken, new CookieOptions
                    {
                        Expires = DateTimeOffset.Now.AddDays(24),
                        HttpOnly = true
                    });
                    return RedirectToAction("Index", "Home");
                }

                Response.Cookies.Append("token", user.RefreshToken, new CookieOptions
                {
                    Expires = DateTimeOffset.Now.AddDays(24),
                    HttpOnly = true
                });
                ModelState.AddModelError("Password", "Email or Password Is Incorrect. Check the details.");
            }
            return View(command);
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterCommand command, CancellationToken cancelToken)
        {
            await _authorizationService.Register(command, cancelToken);
            return RedirectToAction("Index", "Home");
        }

        [TypeFilter(typeof(Auth))]
        public IActionResult Logout()
        {
            UserEntity _user = RouteData.Values["loggedUser"] as UserEntity;
            if (_user != null)
            {
                _user.RefreshToken = null;
            }
            _context.SaveChanges();
            Response.Cookies.Delete("token");
            return RedirectToAction("index", "login");
        }


    }
}