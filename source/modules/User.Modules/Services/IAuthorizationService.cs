using Identity.Module.Response;
using User.Module.Commands;

namespace User.Module.Services
{
    public interface IAuthorizationService
    {
        public Task<JWTResponse> Login(LoginCommand request);
        public Task<bool> Register(RegisterCommand request, CancellationToken cancellationToken);
    }
}
