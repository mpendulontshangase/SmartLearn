using Abp.Authorization;
using SmartLearn.Authorization.Roles;
using SmartLearn.Authorization.Users;

namespace SmartLearn.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
