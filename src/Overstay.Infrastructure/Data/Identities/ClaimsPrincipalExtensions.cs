using System.Security.Claims;

namespace Overstay.Infrastructure.Data.Identities;

public static class ClaimsPrincipalExtensions
{
    public static Guid? GetUserId(this ClaimsPrincipal user)
    {
        var id = user.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        return Guid.TryParse(id, out var guid) ? guid : (Guid?)null;
    }
}
