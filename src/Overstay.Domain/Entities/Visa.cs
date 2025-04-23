using Overstay.Domain.Constants;

namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a visa entity within the domain.
/// A Visa is associated with a user and a specific visa type, and contains details about
/// the arrival date and expiration date of the visa.
/// </summary>
public class Visa : Entity
{
    public DateTime ArrivalDate { get; }
    public DateTime ExpireDate { get; private set; }

    public Guid VisaTypeId { get; set; }
    public Guid UserId { get; set; }

    public VisaType VisaType { get; } = null!;
    public User User { get; set; } = null!;

    protected Visa() { }

    public Visa(DateTime? arrivalDate, DateTime? expireDate, VisaType type)
    {
        VisaType = type ?? throw new ArgumentNullException(nameof(type), "VisaType is required.");
        ArrivalDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
            arrivalDate ?? DateTime.Now,
            Constant.ThailandTimezoneId
        );
        ExpireDate = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(
            expireDate ?? DateTime.Now,
            Constant.ThailandTimezoneId
        );
    }

    public bool IsExpired()
    {
        return ExpireDate
            < TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
    }
}
