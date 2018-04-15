using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace Freedom.Template.Controllers
{
    public abstract class TemplateControllerBase: AbpController
    {
        protected TemplateControllerBase()
        {
            LocalizationSourceName = TemplateConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
