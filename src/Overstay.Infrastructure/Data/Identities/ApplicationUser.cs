using Microsoft.AspNetCore.Identity;

namespace Overstay.Infrastructure.Data.Identities;

public class ApplicationUser : IdentityUser<Guid>
{
    public required User DomainUser { get; init; }
}
