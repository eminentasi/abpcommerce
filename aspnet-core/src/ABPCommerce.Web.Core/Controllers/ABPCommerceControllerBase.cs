using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace ABPCommerce.Controllers
{
    public abstract class ABPCommerceControllerBase: AbpController
    {
        protected ABPCommerceControllerBase()
        {
            LocalizationSourceName = ABPCommerceConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
