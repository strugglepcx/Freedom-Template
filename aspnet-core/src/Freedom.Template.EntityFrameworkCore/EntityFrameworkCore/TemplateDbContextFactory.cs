using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Freedom.Template.Configuration;
using Freedom.Template.Web;

namespace Freedom.Template.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class TemplateDbContextFactory : IDesignTimeDbContextFactory<TemplateDbContext>
    {
        public TemplateDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<TemplateDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            TemplateDbContextConfigurer.Configure(builder, configuration.GetConnectionString(TemplateConsts.ConnectionStringName));

            return new TemplateDbContext(builder.Options);
        }
    }
}
