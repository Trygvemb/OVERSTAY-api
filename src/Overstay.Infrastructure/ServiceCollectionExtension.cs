using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Data.DbContexts;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure;

public static class ServiceCollectionExtension
{
    /// <summary>
    /// Adds the infrastructure layer services to the service collection, including database context
    /// configuration for the application.
    /// </summary>
    /// <param name="services">The service collection to which the infrastructure layer services are added.</param>
    /// <param name="configuration">The application configuration used to load database options.</param>
    /// <returns>The updated service collection with the infrastructure layer services registered.</returns>
    public static IServiceCollection AddInfrastructureLayer(
        this IServiceCollection services,
        IConfiguration configuration
    )
    {
        var dbOptions = DatabaseOptions.Load(configuration);

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(
                dbOptions.ConnectionString,
                mysqlOptions =>
                {
                    mysqlOptions.MigrationsAssembly("Overstay.Infrastructure");
                    mysqlOptions.EnableRetryOnFailure();
                    mysqlOptions.CommandTimeout(60);
                }
            )
        );
        
        return services;
    }
}
