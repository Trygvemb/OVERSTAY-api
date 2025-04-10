namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a country entity that includes information about its name,
/// ISO code, and the associated users.
/// </summary>
public class Country : Entity
{
    public string Name { get; init; } = string.Empty;
    public string IsoCode { get; init; } = string.Empty;
    public virtual ICollection<User> Users { get; set; } = new HashSet<User>();
}
