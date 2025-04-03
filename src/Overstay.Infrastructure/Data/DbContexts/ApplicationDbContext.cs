using Microsoft.EntityFrameworkCore;
using Overstay.Domain.Entities;
using Overstay.Domain.Entities.Countries;

namespace Overstay.Infrastructure.Data.DbContexts;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

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

            modelBuilder
                .Entity(entityType.ClrType)
                .Property(nameof(Entity.Id))
                .HasDefaultValueSql("NEWSEQUENTIALID()")
                .ValueGeneratedOnAdd();
        }
    }
}
