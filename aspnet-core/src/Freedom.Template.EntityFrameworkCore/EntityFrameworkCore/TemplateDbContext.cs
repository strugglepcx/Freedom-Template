using Microsoft.EntityFrameworkCore;
using Abp.Zero.EntityFrameworkCore;
using Freedom.Template.Authorization.Roles;
using Freedom.Template.Authorization.Users;
using Freedom.Template.Domain;
using Freedom.Template.MultiTenancy;
using Microsoft.Extensions.Logging;

namespace Freedom.Template.EntityFrameworkCore
{
    public class TemplateDbContext : AbpZeroDbContext<Tenant, Role, User, TemplateDbContext>
    {
        /* Define a DbSet for each entity of the application */
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }

        public TemplateDbContext(DbContextOptions<TemplateDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
