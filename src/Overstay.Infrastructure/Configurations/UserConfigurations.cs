using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Overstay.Infrastructure.Configurations;

public class UserConfigurations : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("DomainUsers");

        builder.HasKey(u => u.Id);

        // Navigation properties configuration
        builder
            .HasOne(u => u.Notification)
            .WithOne(n => n.User)
            .HasForeignKey<Notification>(n => n.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(u => u.Country)
            .WithMany()
            .HasForeignKey(u => u.CountryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder
            .HasMany(u => u.Visas)
            .WithOne(v => v.User)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        // Basic properties
        builder.Property(u => u.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired();
        builder.Property(u => u.CreatedAt).ValueGeneratedOnAdd().HasColumnName("CreatedAt");
        builder.Property(u => u.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnName("UpdatedAt");
        builder.Property(u => u.CountryId).HasColumnName("CountryId");
        builder.Property(u => u.FirstName).HasColumnName("Firstname");
        builder.Property(u => u.LastName).HasColumnName("Lastname");
    }
}
