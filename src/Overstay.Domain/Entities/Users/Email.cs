namespace Overstay.Domain.Entities.Users;

public class Email
{
    public string Value { get; private set; }

    public Email(string value)
    {
        ValidateEmail(value);
        Value = value;
    }
    public void Update(string value)
    {
        ValidateEmail(value);
        Value = value;
    }

    private void ValidateEmail(string email)
    {
        if (string.IsNullOrWhiteSpace(email))
            throw new ArgumentException("Email cannot be empty.", nameof(email));
        if (!IsValidEmail(email))
            throw new ArgumentException("Invalid email format.", nameof(email));
    }
    
    private bool IsValidEmail(string email)
    {
        // Simple regex for email validation
        var emailRegex = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return System.Text.RegularExpressions.Regex.IsMatch(email, emailRegex);
    }
    
}
