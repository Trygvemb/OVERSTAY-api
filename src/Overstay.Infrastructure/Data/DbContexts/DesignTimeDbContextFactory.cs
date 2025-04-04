using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Overstay.Infrastructure.Configurations;

namespace Overstay.Infrastructure.Data.DbContexts;

public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../Overstay.API"))
            .AddJsonFile("appsettings.json")
            .AddJsonFile("appsettings.Development.json", optional: true)
            .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(
            connectionString!,
            sqlServerOptions =>
                sqlServerOptions
                    .MigrationsAssembly("Overstay.Infrastructure")
                    .MigrationsHistoryTable("__EFMigrationsHistory", "overstay")
                    .EnableRetryOnFailure(5, TimeSpan.FromSeconds(30), null)
        );

        // Create SeedConfigurations options
        var seedConfigurations = new SeedConfigurations();
        configuration.GetSection("SeedData").Bind(seedConfigurations);
        var seedOptions = Options.Create(seedConfigurations);

        return new ApplicationDbContext(optionsBuilder.Options, null!);
    }
}
