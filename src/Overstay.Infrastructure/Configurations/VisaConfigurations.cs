using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Overstay.Infrastructure.Configurations;

public class VisaConfigurations : IEntityTypeConfiguration<Visa>
{
    public void Configure(EntityTypeBuilder<Visa> builder)
    {
        builder.ToTable("Visas");

        builder.HasKey(v => v.Id);
        builder
            .HasOne(v => v.VisaType)
            .WithMany()
            .HasForeignKey(v => v.VisaTypeId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Property(v => v.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired();
        builder.Property(v => v.CreatedAt).ValueGeneratedOnAdd().HasColumnName("CreatedAt");
        builder.Property(v => v.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnName("UpdatedAt");
        builder.Property(v => v.ArrivalDate).HasColumnName("ArrivalDate");
        builder.Property(v => v.ExpireDate).HasColumnName("ExpireDate");
        builder.Property(v => v.VisaTypeId).HasColumnName("VisaTypeId").IsRequired();
    }
}
