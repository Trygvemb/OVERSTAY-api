using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Overstay.Domain.Entities;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Data.Identities;
using Overstay.Infrastructure.Data.Seeds;

namespace Overstay.Infrastructure.Data.DbContexts;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>(options)
{
    public new DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Visa> Visas { get; set; }
    public DbSet<VisaType> VisaTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.ConfigureWarnings(warnings =>
            warnings.Ignore(RelationalEventId.PendingModelChangesWarning)
        );
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Configure Identity tables to use a specific schema (optional)
        modelBuilder.Entity<ApplicationUser>().ToTable("Users", "identity");
        modelBuilder.Entity<IdentityRole<Guid>>().ToTable("Roles", "identity");
        modelBuilder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles", "identity");
        modelBuilder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims", "identity");
        modelBuilder.Entity<IdentityUserLogin<Guid>>().ToTable("UserLogins", "identity");
        modelBuilder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims", "identity");
        modelBuilder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens", "identity");

        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        DefaultConfigurations.ConfigureEntityDefaults(modelBuilder);

        // Seed data without checking database contents
        CountrySeed.SeedCountries(modelBuilder, Countries);
        VisaTypeSeed.SeedVisaTypes(modelBuilder, VisaTypes);
        IdentitySeed.SeedRoles(modelBuilder);
        IdentitySeed.SeedUsers(modelBuilder);
        IdentitySeed.SeedUserRoles(modelBuilder);
    }
}
