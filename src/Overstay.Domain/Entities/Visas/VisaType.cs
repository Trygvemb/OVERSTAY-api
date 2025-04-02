using Overstay.Domain.Entities.Bases;

namespace Overstay.Domain.Entities.Visas;

public class VisaType : EntityBase
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DurationInDays { get; set; }
    public bool IsMultipleEntry { get; set; }
}
