using Overstay.Domain.Entities.Countries;
using Overstay.Domain.Entities.Notifications;
using Overstay.Domain.Entities.Visas;

namespace Overstay.Domain.Entities.Users;

/// <summary>
/// Represents a user entity with personal and account-related information.
/// </summary>
public class User : Entity
{
    #region Fields, ForeignKeys, Navigation Properties

    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public Email? Email { get; set; }
    public Password? Password { get; }
    public UserName? UserName { get; }

    public Guid? CountryId { get; set; }

    public virtual Country? Country { get; set; }
    public virtual Notification? Notification { get; set; }
    public virtual ICollection<Visa>? Visas { get; set; } = new HashSet<Visa>();

    #endregion

    protected User() { }

    public User(
        string firstname,
        string lastName,
        Email email,
        UserName userName,
        Password password
    )
    {
        FirstName = firstname;
        LastName = lastName;
        Email = email ?? throw new ArgumentNullException(nameof(email), "Email is required.");
        UserName =
            userName ?? throw new ArgumentNullException(nameof(userName), "UserName is required.");
        Password =
            password ?? throw new ArgumentNullException(nameof(password), "Password is required.");
    }
}
