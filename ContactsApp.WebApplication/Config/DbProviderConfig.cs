using Microsoft.EntityFrameworkCore;

namespace ContactsApp.WebApplication.Config
{
    public static class DbProviderConfig
    {
        public static DbContextOptions GetNpgSqlOptions(this DbContextOptionsBuilder builder, IConfiguration config)
        {
            var connection = config.GetConnectionString("PostgreSqlConnection");
            return builder
                .UseNpgsql(connection, b => b.MigrationsAssembly("ContactsApp.WebApplication"))
                .Options;
        }
    }
}
