using FinalProject.Domain.Entities;
using Microsoft.IdentityModel.Tokens;
using Identity.Module.Auth;
using IdentityModule.Queries;
using Infrastructure.Identity;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FinalProject.SharedKernel.Domain.Settings;

namespace IdentityModule.Auth
{
    public class UserManager : IUserManager
	{
		private readonly JWTSettings _settings;
		private readonly IClaimsManager _claimsManager;
		private readonly IUserQueries _userQueries;
		public UserManager(IOptions<JWTSettings> settings, IClaimsManager claimsManager, IUserQueries userQueries)
		{
			_claimsManager = claimsManager ?? throw new ArgumentNullException(nameof(claimsManager));
			ArgumentNullException.ThrowIfNull(settings);
			_settings = settings.Value;
			_userQueries = userQueries;
		}

		public (string token, DateTime expiresAt) GenerateJwtToken(UserEntity user)
		{
			var claims = new List<Claim>
			{
				new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};
			claims.AddRange(_claimsManager.GetUserClaims(user));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Key));
			var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
			var expiresAt = DateTime.UtcNow.Date.AddDays(1).AddHours(1);


			var token = new JwtSecurityToken(
				_settings.Issuer,
				_settings.Audience,
				claims,
				expires: expiresAt,
				signingCredentials: creds
			);

			JwtSecurityTokenHandler tokenHandler = new();
			return (tokenHandler.WriteToken(token), expiresAt);
		}

		public Task<UserEntity> GetCurrentUser()
		{
			int currentUserId = GetCurrentUserId();
			return _userQueries.FindAsync(currentUserId);
		}

		public int GetCurrentUserId()
		{
			return _claimsManager.GetCurrentUserId();
		}

		public string GetCurrentUserName()
		{
			return _claimsManager.GetCurrentUserName();
		}
	}
}
