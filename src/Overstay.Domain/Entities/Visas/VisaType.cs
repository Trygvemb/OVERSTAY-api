namespace Overstay.Domain.Entities.Visas;

public class VisaType : Entity
{
    public string? Name { get; set; }
    public string? Description { get; set; }
    public int DurationInDays { get; set; }
    public bool IsMultipleEntry { get; set; }

    // Navigation property
    public virtual ICollection<Visa> Visas { get; set; } = new HashSet<Visa>();
}
