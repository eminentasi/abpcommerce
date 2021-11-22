using Abp.Authorization;
using ABPCommerce.Authorization.Roles;
using ABPCommerce.Authorization.Users;

namespace ABPCommerce.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
