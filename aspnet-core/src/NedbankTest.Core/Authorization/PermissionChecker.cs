using Abp.Authorization;
using NedbankTest.Authorization.Roles;
using NedbankTest.Authorization.Users;

namespace NedbankTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
