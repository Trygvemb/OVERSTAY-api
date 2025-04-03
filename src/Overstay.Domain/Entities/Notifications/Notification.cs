using Overstay.Domain.Entities.Users;

namespace Overstay.Domain.Entities.Notifications;

public class Notification : Entity
{
    #region Fields, ForeignKeys, Navigation Properties
    public bool EmailNotification { get; set; }
    public bool SmsNotification { get; set; }
    public bool PushNotification { get; set; }
    public virtual User User { get; init; } = null!;
    #endregion
}
