namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a visa type within the domain.
/// Holds information about the type of visa, including its name, description,
/// duration, and entry-related attributes.
/// </summary>
public class VisaType : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DurationInDays { get; set; }
    public bool IsMultipleEntry { get; set; }

    public virtual ICollection<Visa> Visas { get; set; } = new HashSet<Visa>();
}
