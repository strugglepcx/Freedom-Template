using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace Freedom.Template.EntityFrameworkCore
{
    public static class TemplateDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<TemplateDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<TemplateDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
