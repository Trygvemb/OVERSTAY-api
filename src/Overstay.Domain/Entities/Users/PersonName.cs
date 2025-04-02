namespace Overstay.Domain.Entities.Users;

public class PersonName
{
    public string FirstName { get; }
    public string LastName { get; }

    public PersonName(string firstName, string lastName)
    {
        if (string.IsNullOrWhiteSpace(firstName))
            throw new ArgumentException("First name is invalid.", nameof(firstName));
        if (string.IsNullOrWhiteSpace(lastName))
            throw new ArgumentException("Last name is invalid.", nameof(lastName));

        FirstName = firstName;
        LastName = lastName;
    }
}
