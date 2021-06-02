using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using ThinkAM.ThinkEvent.Authorization.Roles;
using ThinkAM.ThinkEvent.Authorization.Users;
using ThinkAM.ThinkEvent.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace ThinkAM.ThinkEvent.Identity
{
    public class SecurityStampValidator : AbpSecurityStampValidator<Tenant, Role, User>
    {
        public SecurityStampValidator(
            IOptions<SecurityStampValidatorOptions> options,
            SignInManager signInManager,
            ISystemClock systemClock,
            ILoggerFactory loggerFactory) 
            : base(options, signInManager, systemClock, loggerFactory)
        {
        }
    }
}
