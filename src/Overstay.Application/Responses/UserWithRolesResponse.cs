namespace Overstay.Application.Responses;

public class UserWithRolesResponse
{
    public Guid Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public List<string> Roles { get; set; } = [];
}
