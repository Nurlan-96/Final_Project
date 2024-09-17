using CryptoHelper;
using Domain.Exceptions;
using FinalProject.Domain.Entities;
using FinalProject.Domain.Reporistories;
using Identity.Module.Auth;
using Identity.Module.Response;
using IdentityModule.Queries;
using System.Threading;

namespace User.Module.Services
{
    public class LoginService(IUserManager userManager, IUserQueries userQueries, IUserRepository userRepository) : ILoginService
    {
        private readonly IUserManager _userManager = userManager
            ?? throw new ArgumentNullException(nameof(userManager));

        private readonly IUserQueries _userQueries = userQueries
            ?? throw new ArgumentNullException(nameof(userQueries));

        private readonly IUserRepository _userRepository = userRepository
            ?? throw new ArgumentNullException(nameof(userRepository));


        public async Task<JWTResponse> Login(string username, string password)
        {
            var email = username.ToLower();

            var user = await _userQueries.FindAsync(email)
                ?? throw new EntityNotFoundException<UserEntity>();

            if (!Crypto.VerifyHashedPassword(user.PasswordHash, password))
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
    }
}