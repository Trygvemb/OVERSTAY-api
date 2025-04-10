namespace Overstay.Domain.Entities;

/// <summary>
/// Represents notification preferences and settings for a user.
/// Provides options for enabling or disabling email, SMS, and push notifications.
/// </summary>
public class Notification : Entity
{
    public bool EmailNotification { get; set; }
    public bool SmsNotification { get; set; }
    public bool PushNotification { get; set; }
    public required Guid UserId { get; set; }
    public User User { get; init; } = null!;
    
    protected Notification() { }
}
