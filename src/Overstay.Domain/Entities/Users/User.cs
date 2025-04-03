using Overstay.Domain.Entities.Countries;
using Overstay.Domain.Entities.Notifications;
using Overstay.Domain.Entities.Visas;

namespace Overstay.Domain.Entities.Users;

public class User : Entity
{
    #region Fields, ForeignKeys, Navigation Properties

    public PersonName PersonName { get; }
    public Email Email { get; }
    public Password Password { get; }
    public UserName UserName { get; }
    public DateTime? DateOfBirth { get; set; }

    public Guid CountryId { get; set; }
    public Guid NotificationId { get; set; }

    public virtual Country Country { get; set; }
    public virtual Notification Notification { get; set; }
    public virtual ICollection<Visa>? Visas { get; set; } = new HashSet<Visa>();

    #endregion

    protected User() { }

    public User(
        PersonName personName,
        Email email,
        UserName userName,
        Password password,
        DateTime? dateOfBirth
    )
    {
        PersonName =
            personName ?? throw new ArgumentNullException(nameof(personName), "Name is required.");
        Email = email ?? throw new ArgumentNullException(nameof(email), "Email is required.");
        UserName =
            userName ?? throw new ArgumentNullException(nameof(userName), "UserName is required.");
        Password =
            password ?? throw new ArgumentNullException(nameof(password), "Password is required.");
        DateOfBirth = dateOfBirth;
    }
}
