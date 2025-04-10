using Microsoft.AspNetCore.Identity;
using Overstay.Domain.Entities.Users;

namespace Overstay.Infrastructure.Data.Identities;

public class ApplicationUser : IdentityUser
{
    public Guid DomainUserId { get; init; }
    public User DomainUser { get; init; } = null!;
}
