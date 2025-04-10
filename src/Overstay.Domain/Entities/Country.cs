namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a country entity that includes information about its name,
/// ISO code, and the associated users.
/// </summary>
public class Country : Entity
{
    public required string Name { get; init; }
    public required string IsoCode { get; init; }
}
