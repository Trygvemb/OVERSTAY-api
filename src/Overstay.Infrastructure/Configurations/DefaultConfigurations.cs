namespace Overstay.Infrastructure.Configurations;

public class DefaultConfigurations
{
    public static void ConfigureEntityDefaults(ModelBuilder modelBuilder)
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
}
