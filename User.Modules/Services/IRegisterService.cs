using FinalProject.Domain.Entities.RoleAggregate;
using Identity.Module.Response;
using User.Module.Commands;

namespace User.Module.Services
{
    public interface IRegisterService
    {
        public Task<bool> Register(RegisterCommand request, CancellationToken cancellationToken);

    }
}
