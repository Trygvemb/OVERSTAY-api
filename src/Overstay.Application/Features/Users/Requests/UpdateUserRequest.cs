namespace Overstay.Application.Features.Users.Requests;

public class UpdateUserRequest
{
    public string? UserName { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
}
