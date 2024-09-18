using Identity.Module.Response;
using User.Module.Commands;

namespace User.Module.Services
{
    public interface ILoginService
    {
        public Task<JWTResponse> Login(LoginCommand request);
    }
}
