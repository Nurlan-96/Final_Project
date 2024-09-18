using SharedKernel.Domain.Seedwork;

namespace Domain.Entities.RoleAggergate
{
    public class RoleParameter : Enumeration
    {
        public static RoleParameter SuperAdmin = new(1, RoleName.SuperAdmin);
        public static RoleParameter User = new(2, RoleName.User);
        public static RoleParameter Company = new(3, RoleName.Company);

        public RoleParameter(int id, string name) : base(id, name)
        {

        }

        public RoleParameter()
        {

        }
    }
}
