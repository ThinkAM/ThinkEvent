using Abp.Authorization;
using ThinkAM.ThinkEvent.Authorization.Roles;
using ThinkAM.ThinkEvent.Authorization.Users;

namespace ThinkAM.ThinkEvent.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
