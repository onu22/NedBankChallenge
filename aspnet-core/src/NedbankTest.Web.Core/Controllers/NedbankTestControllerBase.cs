using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace NedbankTest.Controllers
{
    public abstract class NedbankTestControllerBase: AbpController
    {
        protected NedbankTestControllerBase()
        {
            LocalizationSourceName = NedbankTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
