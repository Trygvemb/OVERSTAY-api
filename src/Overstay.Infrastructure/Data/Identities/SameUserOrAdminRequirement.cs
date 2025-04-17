using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Overstay.Application.Commons.Constants;

namespace Overstay.Infrastructure.Data.Identities;

public class SameUserOrAdminRequirement : IAuthorizationRequirement { }

public class SameUserOrAdminHandler : AuthorizationHandler<SameUserOrAdminRequirement, Guid>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        SameUserOrAdminRequirement requirement,
        Guid resourceId
    )
    {
        if (context.User.IsInRole(RoleTypeConstants.Admin))
        {
            context.Succeed(requirement);
            return Task.CompletedTask;
        }

        var userId = context.User.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null || !Guid.TryParse(userId, out var userGuid) || userGuid != resourceId)
            return Task.CompletedTask;

        context.Succeed(requirement);
        return Task.CompletedTask;
    }
}
