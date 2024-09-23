using Microsoft.AspNetCore.Authorization;

namespace Domain.Attributes
{
    public class AuthroizeRolesAttribute : AuthorizeAttribute
    {
        public AuthroizeRolesAttribute(params string[] roles) : base()
        {
            Roles = string.Join(",", roles);
        }
    }
}