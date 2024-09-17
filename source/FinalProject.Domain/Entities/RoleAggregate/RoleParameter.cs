using SharedKernel.Domain.Seedwork;

namespace Domain.Entities.RoleAggergate
{
    public class RoleParameter : Enumeration
    {
        public static RoleParameter SuperAdmin = new(1, RoleName.SuperAdmin);
        public static RoleParameter User = new(2, RoleName.User);
        public static RoleParameter Agent = new(3, RoleName.Agent);

        public RoleParameter(int id, string name) : base(id, name)
        {

        }

        public RoleParameter()
        {

        }
    }
}
