using FinalProject.Domain.Entities;
using System.Security.Claims;

namespace Infrastructure.Identity
{
    public interface IClaimsManager
	{
		int GetCurrentUserId();
		string GetCurrentUserName();
		IEnumerable<Claim> GetUserClaims(UserEntity user);
		Claim GetUserClaim(string claimType);
	}
}