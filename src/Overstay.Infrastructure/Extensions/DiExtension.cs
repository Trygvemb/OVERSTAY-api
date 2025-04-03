using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Overstay.Infrastructure.Data.DbContexts;

namespace Overstay.Infrastructure.Extensions;

public static class DiExtension
{
    public static IServiceCollection AddDataAccessLayer(
        this IServiceCollection services,
        string connectionString
    )
    {
        // Register the DbContext with MySQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseMySql(
                connectionString,
                ServerVersion.AutoDetect(connectionString),
                mysqlOptions =>
                {
                    mysqlOptions.MigrationsAssembly("Overstay.Infrastructure");
                    mysqlOptions.EnableRetryOnFailure();
                    mysqlOptions.CommandTimeout(60);
                }
            )
        );

        // Add other data access layer services here

        return services;
    }
}
