using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Configurations;

public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        builder
            .HasOne(a => a.DomainUser)
            .WithOne()
            .HasForeignKey<User>(u => u.Id)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
