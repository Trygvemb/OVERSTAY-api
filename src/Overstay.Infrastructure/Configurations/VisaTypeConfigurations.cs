using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Overstay.Domain.Entities.Visas;

namespace Overstay.Infrastructure.Configurations;

public class VisaTypeConfigurations : IEntityTypeConfiguration<VisaType>
{
    public void Configure(EntityTypeBuilder<VisaType> builder)
    {
        builder.ToTable("VisaTypes");

        builder.HasKey(v => v.Id);
        builder
            .HasMany(v => v.Visas)
            .WithOne(v => v.VisaType)
            .HasForeignKey(v => v.VisaTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(v => v.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired();
        builder.Property(v => v.CreatedAt).ValueGeneratedOnAdd().HasColumnName("CreatedAt");
        builder.Property(v => v.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnName("UpdatedAt");
        builder.Property(v => v.Name).HasColumnName("Name").IsRequired().HasMaxLength(100);
        builder.Property(v => v.Description).HasColumnName("Description").HasMaxLength(500);
        builder.Property(v => v.DurationInDays).HasColumnName("DurationInDays").IsRequired();
        builder.Property(v => v.IsMultipleEntry).HasColumnName("IsMultipleEntry").IsRequired();
    }
}
