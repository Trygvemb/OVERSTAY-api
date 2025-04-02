using Overstay.Domain.Constants;

namespace Overstay.Domain.Entities.Bases;

public class EntityBase
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; set; } = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
    public DateTime UpdatedAt { get; set; } = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, Constant.ThailandTimezoneId);
}