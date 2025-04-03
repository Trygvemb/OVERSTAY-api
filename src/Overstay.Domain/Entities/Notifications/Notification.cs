namespace Overstay.Domain.Entities.Notifications;

public class Notification : Entity
{
    public bool EmailNotification { get; set; }
    public bool SmsNotification { get; set; }
    public bool PushNotification { get; set; }
}
