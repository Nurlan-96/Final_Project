using FinalProject.Domain.Entities;
using FinalProject.Infrastructure.DAL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FinalProject.Application.Attributes
{
    public class Auth(AppDbContext context) : ActionFilterAttribute
    {
        private readonly AppDbContext _context = context;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.HttpContext.Request.Cookies.TryGetValue("token", out string token))
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Authentication" }));
            }
            UserEntity user = _context.Users.FirstOrDefault(u => u.RefreshToken == token);
            if (user == null)
            {
                context.Result = new RedirectToRouteResult(new RouteValueDictionary(new { action = "Login", controller = "Authentication" }));
            }
            if (context.Controller is Controller controller)
            {
                controller.ViewBag.User = user;
            }
            context.RouteData.Values["loggedUser"] = user;
        }
    }
}
