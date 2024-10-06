using CryptoHelper;
using Domain.Entities.RoleAggergate;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Identity.Module.Auth;
using Identity.Module.Response;
using IdentityModule.Queries;
using User.Module.Commands;

namespace User.Module.Services
{
    public class AuthorizationService(IUserManager userManager, IUserQueries userQueries, IUserRepository userRepository) : IAuthorizationService
    {
        private readonly IUserManager _userManager = userManager
            ?? throw new ArgumentNullException(nameof(userManager));

        private readonly IUserQueries _userQueries = userQueries
            ?? throw new ArgumentNullException(nameof(userQueries));

        private readonly IUserRepository _userRepository = userRepository
            ?? throw new ArgumentNullException(nameof(userRepository));


        public async Task<JWTResponse> Login(LoginCommand request)
        {
            var email = request.Email.ToLower();

            var user = await _userQueries.FindAsync(email)
                ?? throw new EntityNotFoundException<UserEntity>();

            if (!Crypto.VerifyHashedPassword(user.PasswordHash, request.Password))
                throw new UnauthorizedAccessException("Invalid credentials.");

            (string token, DateTime expiresAt) = _userManager.GenerateJwtToken(user);

            string? refreshTokenValue;
            if (user.RefreshToken != null)
            {
                var splitToken = user.RefreshToken.Split("_");

                if (Convert.ToDateTime(splitToken[2]) < DateTime.Now)
                {
                    var refreshToken = $"{Guid.NewGuid()}_{user.Id}_{DateTime.UtcNow.AddDays(30)}";
                    refreshTokenValue = refreshToken;
                    user.UpdateRefreshToken(refreshToken);
                }
                else
                {
                    refreshTokenValue = user.RefreshToken;
                }
            }
            else
            {
                var refreshToken = $"{Guid.NewGuid()}_{user.Id}_{DateTime.UtcNow.AddDays(30)}";
                refreshTokenValue = refreshToken;
                user.UpdateRefreshToken(refreshToken);
            }

            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            return new JWTResponse
            {
                Token = token,
                RefreshToken = refreshTokenValue,
                ExpiresAt = expiresAt
            };
        }
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
        public async Task<JWTResponse> RefreshToken(string refreshToken)
        {
            var splitToken = refreshToken.Split("_");
            var tokenExpiration = Convert.ToDateTime(splitToken[2]);

            if (tokenExpiration < DateTime.UtcNow)
                throw new UnauthorizedAccessException("Refresh token has expired.");

            var user = await _userQueries.FindByRefreshToken(refreshToken)
                ?? throw new EntityNotFoundException<UserEntity>();

            if (user.RefreshToken != refreshToken)
                throw new UnauthorizedAccessException("Invalid refresh token.");

            // Generate new JWT and refresh token
            (string newToken, DateTime expiresAt) = _userManager.GenerateJwtToken(user);

            var newRefreshToken = $"{Guid.NewGuid()}_{user.Id}_{DateTime.UtcNow.AddDays(30)}";
            user.UpdateRefreshToken(newRefreshToken);

            _userRepository.Update(user);
            await _userRepository.UnitOfWork.SaveChangesAsync();

            return new JWTResponse
            {
                Token = newToken,
                RefreshToken = newRefreshToken,
                ExpiresAt = expiresAt
            };
        }

    }
}