namespace Overstay.Domain.Entities;

/// <summary>
/// Represents a user entity with personal and account-related information.
/// </summary>
public class User : Entity
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }

    public Guid? CountryId { get; private set; }

    public Country? Country { get; set; }
    public Notification? Notification { get; set; }
    public ICollection<Visa>? Visas { get; set; } = new HashSet<Visa>();

    protected User() { }

    public User(
        string firstname,
        string lastName
    )
    {
        FirstName = firstname;
        LastName = lastName;
    }
}
