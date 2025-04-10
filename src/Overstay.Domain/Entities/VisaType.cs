namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a visa type within the domain.
/// Holds information about the type of visa, including its name, description,
/// duration, and entry-related attributes.
/// </summary>
public class VisaType : Entity
{
    public string? Name { get; private set; }
    public string? Description { get;  private set; }
    public int DurationInDays { get;  private set; }
    public bool IsMultipleEntry { get;  private set; }

    protected VisaType()
    {
    }
    
    public VisaType(string name, string description, int durationInDays, bool isMultipleEntry)
    {
        Name = name;
        Description = description;
        IsMultipleEntry = isMultipleEntry;
        SetDurationInDays(durationInDays);
    }

    private void SetDurationInDays(int durationInDays)
    {
        if (durationInDays < 0)
            throw new ArgumentException("Duration cannot be negative.", nameof(durationInDays));
        
        DurationInDays = durationInDays;
    }
}
