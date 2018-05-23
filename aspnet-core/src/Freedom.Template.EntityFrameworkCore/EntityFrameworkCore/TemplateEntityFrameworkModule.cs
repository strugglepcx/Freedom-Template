using Abp.EntityFrameworkCore.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.EntityFrameworkCore;
using Freedom.Template.EntityFrameworkCore.Seed;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Freedom.Template.EntityFrameworkCore
{
    [DependsOn(
        typeof(TemplateCoreModule),
        typeof(AbpZeroCoreEntityFrameworkCoreModule))]
    public class TemplateEntityFrameworkModule : AbpModule
    {
        /* Used it tests to skip dbcontext registration, in order to use in-memory database of EF Core */
        public bool SkipDbContextRegistration { get; set; }

        public bool SkipDbSeed { get; set; }

        public override void PreInitialize()
        {
            if (!SkipDbContextRegistration)
            {
                Configuration.Modules.AbpEfCore().AddDbContext<TemplateDbContext>(options =>
                {
                    if (options.ExistingConnection != null)
                    {
                        TemplateDbContextConfigurer.Configure(options.DbContextOptions, options.ExistingConnection);
                    }
                    else
                    {
                        TemplateDbContextConfigurer.Configure(options.DbContextOptions, options.ConnectionString);
                    }
                    options.DbContextOptions.UseLoggerFactory(new LoggerFactory(new[]
                    {
                        new ConsoleLoggerProvider((category, level)
                            => category == DbLoggerCategory.Database.Command.Name
                               && level == LogLevel.Information, true)
                    }));
                });
            }
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(TemplateEntityFrameworkModule).GetAssembly());
        }

        public override void PostInitialize()
        {
            if (!SkipDbSeed)
            {
                SeedHelper.SeedHostDb(IocManager);
            }
        }
    }
}
