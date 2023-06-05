using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace SmartLearn.Controllers
{
    public abstract class SmartLearnControllerBase: AbpController
    {
        protected SmartLearnControllerBase()
        {
            LocalizationSourceName = SmartLearnConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
