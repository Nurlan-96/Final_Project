using FinalProject.SharedKernel.Domain.Settings;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace UserModule.Managers
{
    internal class TokenManager
    {
        private static ClaimsPrincipal GetPrincipal(JWTSettings appSettings, string token)
        {
            JwtSecurityTokenHandler tokenHandler = new();
            JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

            if (jwtToken == null)
                return null;

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(appSettings.Key));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            TokenValidationParameters parameters = new TokenValidationParameters()
            {
                RequireExpirationTime = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateIssuerSigningKey = true,
                ClockSkew = TimeSpan.FromSeconds(0),
                IssuerSigningKey = key
            };
            SecurityToken securityToken;
            ClaimsPrincipal principal = tokenHandler.ValidateToken(token,
                  parameters, out securityToken);
            JwtSecurityToken validJwt = securityToken as JwtSecurityToken;
            return principal;

        }

        public static string ValidateToken(JWTSettings appSettings, string token)
        {
            string username = null;
            ClaimsPrincipal principal = GetPrincipal(appSettings, token);

            if (principal == null)
                return null;
            ClaimsIdentity identity = null;

            try
            {
                identity = (ClaimsIdentity)principal.Identity;
            }
            catch (NullReferenceException)
            {
                return null;
            }
            Claim usernameClaim = identity.FindFirst(ClaimTypes.NameIdentifier);
            username = usernameClaim.Value;
            return username;
        }
    }
}