using Overstay.Domain.Constants;

namespace Overstay.Domain.Entities;

public class Entity
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; } //= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
    public DateTime UpdatedAt { get; init; } //= TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
}
