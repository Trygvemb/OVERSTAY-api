using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Overstay.Domain.Entities.Countries;

namespace Overstay.Infrastructure.Configurations;

public class CountryConfigurations : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired();
        builder.Property(c => c.CreatedAt).ValueGeneratedOnAdd().HasColumnName("CreatedAt");
        builder.Property(c => c.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnName("UpdatedAt");
        builder.Property(c => c.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
        builder.Property(c => c.IsoCode).HasColumnName("IsoCode").IsRequired().HasMaxLength(3);
    }
}
