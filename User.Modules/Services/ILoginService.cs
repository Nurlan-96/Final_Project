using Identity.Module.Response;

namespace User.Module.Services
{
    public interface ILoginService
    {
        public Task<JWTResponse> Login(string username, string password);
    }
}
