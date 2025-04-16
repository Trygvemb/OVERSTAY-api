namespace Overstay.Application.Features.Users.Requests;

public class SignInUserRequest
{
    public required string UserName { get; set; }
    public required string Password { get; set; }
}
