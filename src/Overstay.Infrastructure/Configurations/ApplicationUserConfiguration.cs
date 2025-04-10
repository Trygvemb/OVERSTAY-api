using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        // Rename the Identity table
        builder.ToTable("ApplicationUser");
        
        builder
            .HasOne(u => u.DomainUser)
            .WithOne() // Explicitly state it's one-to-one without navigation property
            .HasForeignKey<ApplicationUser>(u => u.DomainUserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasIndex(u => u.DomainUserId)
            .IsUnique();
    }
}