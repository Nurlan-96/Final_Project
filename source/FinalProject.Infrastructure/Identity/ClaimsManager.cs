using FinalProject.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Security.Authentication;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public class ClaimsManager(IHttpContextAccessor httpContextAccessor) : IClaimsManager
	{
		private readonly IHttpContextAccessor _httpContextAccessor = httpContextAccessor;
        public int? GetCurrentUserId()
        {
            var claimValue = GetUserClaim(ClaimTypes.NameIdentifier);

            if (claimValue == null) // No claim means no authenticated user or missing claim
                return null;

            if (!int.TryParse(claimValue, out var currentUserId))
                throw new AuthenticationException("Can't parse claim value to required type");

            return currentUserId;
        }

        public string GetCurrentUserName()
        {
            var claimValue = GetUserClaim(ClaimTypes.Name);

            if (claimValue == null)
                throw new AuthenticationException("User does not have a name claim or is not authenticated");

            return claimValue;
        }


        public string GetUserClaim(string claimType)
        {
            ClaimsPrincipal? user = _httpContextAccessor.HttpContext.User;

            if (!user.Identity.IsAuthenticated)
                return null;  // Return null if the user is not authenticated

            Claim? claim = user.FindFirst(claimType);

            return claim?.Value;  // Return the claim's value or null if the claim is missing
        }


        public IEnumerable<Claim> GetUserClaims(UserEntity user)
		{
			return new List<Claim>
			{
				new(ClaimTypes.NameIdentifier, user.Id.ToString()),
				new(ClaimTypes.Email, user.Email),
				new (ClaimTypes.Role, user.Role.Name)
			};
		}
    }
}