namespace Overstay.Domain.Entities.Users;

public class UserName
{
    public string Value { get; }

    public UserName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Username cannot be empty or whitespace.", nameof(value));

        if (value.Length is < 3 or > 20)
            throw new ArgumentException(
                "Username must be between 3 and 20 characters long.",
                nameof(value)
            );

        Value = value;
    }
}
