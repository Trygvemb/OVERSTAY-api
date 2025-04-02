namespace Overstay.Domain.Entities.Users;

public class Password
{
    public string Value { get; }

    public Password(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Password cannot be empty.", nameof(value));

        if (!IsValidPassword(value))
            throw new ArgumentException("Invalid password format.", nameof(value));

        Value = value;
    }

    private bool IsValidPassword(string password)
    {
        // Password must be at least 8 characters long and contain at least one digit, one uppercase letter, and one lowercase letter
        var passwordRegex = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$";
        return System.Text.RegularExpressions.Regex.IsMatch(password, passwordRegex);
    }
}
