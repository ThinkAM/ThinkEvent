using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ThinkAM.ThinkEvent.Controllers
{
    public abstract class ThinkEventControllerBase: AbpController
    {
        protected ThinkEventControllerBase()
        {
            LocalizationSourceName = ThinkEventConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
