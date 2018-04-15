using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Freedom.Template.Authorization.Roles;
using Freedom.Template.Authorization.Users;
using Freedom.Template.MultiTenancy;

namespace Freedom.Template.EntityFrameworkCore
{
    public class TemplateDbContext : AbpZeroDbContext<Tenant, Role, User, TemplateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        
        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }
    }
}
