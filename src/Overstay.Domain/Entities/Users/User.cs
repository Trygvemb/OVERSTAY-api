using Overstay.Domain.Entities.Bases;
using Overstay.Domain.Entities.Countries;
using Overstay.Domain.Entities.Notifications;
using Overstay.Domain.Entities.Visas;

namespace Overstay.Domain.Entities.Users;

public class User : EntityBase
{
    public PersonName PersonName { get; }
    public Email Email { get; }
    public Password Password { get; }
    public UserName UserName { get; }
    public DateTime? DateOfBirth { get; set; }
    public Country Nationality { get; set; }

    /// Navigation properties
    public Notification notification { get; set; }
    public Guid notificationId { get; set; }
    public IList<Visa>? Visas { get; set; }

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
