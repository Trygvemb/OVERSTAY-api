using Overstay.Domain.Entities.Bases;

namespace Overstay.Domain.Entities.Notifications;

public class Notification : EntityBase 
{
    public bool EmailNotification { get; set; }
    public bool SmsNotification { get; set; }
    public bool PushNotification { get; set; }
}