using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Overstay.Infrastructure.Configurations;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Data.DbContexts;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
{
    public new DbSet<User> Users { get; set; }
    public DbSet<Country> Countries { get; set; }
    public DbSet<Notification> Notifications { get; set; }
    public DbSet<Visa> Visas { get; set; }
    public DbSet<VisaType> VisaTypes { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Apply configurations
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        DefaultConfigurations.ConfigureEntityDefaults(modelBuilder);
    }
}
