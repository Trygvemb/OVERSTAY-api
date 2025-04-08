using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Overstay.Domain.Entities;
using Overstay.Domain.Entities.Countries;
using Overstay.Domain.Entities.Notifications;
using Overstay.Domain.Entities.Users;
using Overstay.Domain.Entities.Visas;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Data.Seeds;

namespace Overstay.Infrastructure.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    private readonly SeedConfigurations _seedConfigurations;

    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Country> Countries { get; set; } = null!;
    public DbSet<Notification> Notifications { get; set; } = null!;
    public DbSet<Visa> Visas { get; set; } = null!;
    public DbSet<VisaType> VisaTypes { get; set; } = null!;

    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options,
        IOptions<SeedConfigurations>? configuration = null
    )
        : base(options)
    {
        _seedConfigurations = configuration?.Value ?? new SeedConfigurations();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        ConfigureEntityDefaults(modelBuilder);
        //SeedData(modelBuilder);
    }

    private void ConfigureEntityDefaults(ModelBuilder modelBuilder)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            if (!typeof(Entity).IsAssignableFrom(entityType.ClrType))
                continue;

            modelBuilder
                .Entity(entityType.ClrType)
                .Property(nameof(Entity.UpdatedAt))
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAddOrUpdate();

            modelBuilder
                .Entity(entityType.ClrType)
                .Property(nameof(Entity.CreatedAt))
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .ValueGeneratedOnAdd();
        }
    }

    /// <summary>
    /// Seeds initial data into the database based on the configuration settings provided in SeedConfigurations.
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder instance used to configure entity mappings and seed data.</param>
    private void SeedData(ModelBuilder modelBuilder)
    {
        if (_seedConfigurations.SeedCountries && !Countries.Any())
        {
            CountrySeed.SeedCountries(modelBuilder);
        }

        if (_seedConfigurations.SeedVisaTypes && !VisaTypes.Any())
        {
            VisaTypeSeed.SeedVisaTypes(modelBuilder);
        }

        if (_seedConfigurations.SeedUsers && !Users.Any())
        {
            // UserSeeds.SeedUsers(modelBuilder);
        }

        if (_seedConfigurations.SeedVisas && !Visas.Any())
        {
            // VisaSeed.SeedVisas(modelBuilder);
        }

        if (_seedConfigurations.SeedNotifications && !Notifications.Any())
        {
            // NotificationSeed.SeedNotifications(modelBuilder);
        }
    }
}
