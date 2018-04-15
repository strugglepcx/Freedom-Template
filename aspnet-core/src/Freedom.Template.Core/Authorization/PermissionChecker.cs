using Abp.Authorization;
using Freedom.Template.Authorization.Roles;
using Freedom.Template.Authorization.Users;

namespace Freedom.Template.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
