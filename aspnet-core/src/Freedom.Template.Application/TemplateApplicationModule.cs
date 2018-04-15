using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Freedom.Template.Authorization;

namespace Freedom.Template
{
    [DependsOn(
        typeof(TemplateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class TemplateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<TemplateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(TemplateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );
        }
    }
}
