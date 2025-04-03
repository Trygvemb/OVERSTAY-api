using Overstay.Domain.Constants;

namespace Overstay.Domain.Entities.Visas;

public class Visa : Entity
{
    public DateTime ArrivalDate { get; }
    public DateTime ExpireDate { get; private set; }
    public VisaType VisaType { get; }

    /// Navigation properties
    public Guid VisaTypeId { get; set; }

    public Visa(DateTime? arrivalDate, DateTime? expireDate, VisaType type)
    {
        VisaType = type ?? throw new ArgumentNullException(nameof(type), "VisaType is required.");
        ArrivalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
            arrivalDate ?? DateTime.Now,
            Constant.ThailandTimezoneId
        );
        ExpireDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
            expireDate ?? GetExpirationDateFromType(),
            Constant.ThailandTimezoneId
        );
    }

    public bool IsExpired()
    {
        return ExpireDate
            < TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
    }

    public void SetExpireDateFromVisaType()
    {
        ExpireDate = ArrivalDate.Add(TimeSpan.FromDays(VisaType.DurationInDays));
    }

    public DateTime GetExpirationDateFromType()
    {
        return ArrivalDate.Add(TimeSpan.FromDays(VisaType.DurationInDays));
    }
}
