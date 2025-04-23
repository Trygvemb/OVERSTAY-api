namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a visa type within the domain.
/// Holds information about the type of visa, including its name, description,
/// duration, and entry-related attributes.
/// </summary>
public class VisaType : Entity
{
    public string? Name { get; private set; }
    public string? Description { get; private set; }
    public bool IsMultipleEntry { get; private set; }

    public VisaType() { }

    public VisaType(string name, string description, bool isMultipleEntry)
    {
        Name = name;
        Description = description;
        IsMultipleEntry = isMultipleEntry;
    }
}
