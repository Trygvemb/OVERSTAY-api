namespace Overstay.Domain.Entities;

/// <summary>
/// Base class for entities within the domain.
/// Provides common properties for all entities, such as Id, CreatedAt, and UpdatedAt.
/// </summary>
public class Entity
{
    public Guid Id { get; init; }
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
}
