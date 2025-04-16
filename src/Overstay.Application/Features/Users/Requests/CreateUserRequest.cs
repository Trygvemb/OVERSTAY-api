namespace Overstay.Application.Features.Users.Requests;

public class CreateUserRequest
{
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Guid CountryId { get; set; }
}
