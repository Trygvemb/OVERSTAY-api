namespace Overstay.Domain.Entities.Users;

public class Email
{
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new ArgumentException("Email cannot be empty.", nameof(value));

        if (!IsValidEmail(value))
            throw new ArgumentException("Invalid email format.", nameof(value));

        Value = value;
    }

    private bool IsValidEmail(string email)
    {
        // Simple regex for email validation
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailRegex);
    }
}
