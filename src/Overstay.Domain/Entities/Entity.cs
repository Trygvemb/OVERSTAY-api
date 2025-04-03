using Overstay.Domain.Constants;

namespace Overstay.Domain.Entities;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } =
        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
    public DateTime UpdatedAt { get; set; } =
        TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
}
