namespace Overstay.Application.Features.Users.Responses;

public class UserWithRolesResponse
{
    public Guid Id { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<string> Roles { get; set; } = [];
}
