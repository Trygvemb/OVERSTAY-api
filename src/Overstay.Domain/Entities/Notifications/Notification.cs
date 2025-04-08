using Overstay.Domain.Entities.Users;

namespace Overstay.Domain.Entities.Notifications;

/// <summary>
/// Represents notification preferences and settings for a user.
/// Provides options for enabling or disabling email, SMS, and push notifications.
/// </summary>
public class Notification : Entity
{
    #region Fields, ForeignKeys, Navigation Properties
    public bool EmailNotification { get; set; }
    public bool SmsNotification { get; set; }
    public bool PushNotification { get; set; }
    public required Guid UserId { get; set; }
    public virtual User User { get; init; } = null!;
    #endregion
}
