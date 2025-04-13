using Microsoft.AspNetCore.Identity;

namespace Overstay.Infrastructure.Data.Identities;

public class ApplicationUser : IdentityUser<Guid>
{
    public User DomainUser { get; init; }
}
