using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Overstay.Domain.Entities.Notifications;

namespace Overstay.Infrastructure.Configurations;

public class NotificationConfigurations : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications");

        builder.HasKey(n => n.Id);

        builder.Property(n => n.Id).ValueGeneratedOnAdd().HasColumnName("Id").IsRequired();
        builder.Property(n => n.CreatedAt).ValueGeneratedOnAdd().HasColumnName("CreatedAt");
        builder.Property(n => n.UpdatedAt).ValueGeneratedOnAddOrUpdate().HasColumnName("UpdatedAt");
        builder.Property(n => n.EmailNotification).HasColumnName("EmailNotification");
        builder.Property(n => n.PushNotification).HasColumnName("PushNotification");
        builder.Property(n => n.SmsNotification).HasColumnName("SmsNotification");
    }
}
