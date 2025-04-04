using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Data.DbContexts;

namespace Overstay.Infrastructure.Extensions;

public static class DiExtension
{
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var dbOptions = DatabaseOptions.Load(configuration);

        // Register the DbContext with MySQL
        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                dbOptions.ConnectionString,
                mysqlOptions =>
                {
                    mysqlOptions.MigrationsAssembly("Overstay.Infrastructure/Data");
                    mysqlOptions.EnableRetryOnFailure();
                    mysqlOptions.CommandTimeout(60);
                }
            )
        );

        return services;
    }
}
