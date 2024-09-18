using CryptoHelper;
using Domain.Entities.RoleAggergate;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using IdentityModule.Queries;
using User.Module.Commands;
using User.Module.Services;

namespace UserModule.Handlers
{
    public class RegisterService(IUserQueries userQueries, IUserRepository userRepository) : IRegisterService
    {

        private readonly IUserRepository _userRepository = userRepository;
        private readonly IUserQueries _userQueries = userQueries;
        public async Task<bool> Register(RegisterCommand request, CancellationToken cancellationToken)
        {
            UserEntity existingUser = await _userQueries
                .FindAsync(request.Email);

            if (existingUser != null)
                throw new UnauthorizedAccessException("User already exists.");

            UserEntity user = new();
            user.SetDetails(request.Fullname, request.Email, request.Phone);
            user.ChangePassword(Crypto.HashPassword(request.Password));
            user.SetRole(RoleParameter.User.Id);
            await _userRepository.AddAsync(user);
            await _userRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}