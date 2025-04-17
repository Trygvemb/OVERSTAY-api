using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Results;

namespace Overstay.API.Commons;

public static class AuthHelper
{
    public static Result AuthorizeSameUserOrAdmin(Guid id, ClaimsPrincipal user)
    {
        if (user.IsInRole(RoleTypeConstants.Admin))
        {
            return Result.Success();
        }

        var userId = user.FindFirstValue(ClaimTypes.NameIdentifier);

        if (userId == null || !Guid.TryParse(userId, out var userGuid) || userGuid != id)
        {
            return Result.Failure(UserErrors.AccessDenied);
        }

        return Result.Success();
    }

    // public static ForbidResult? ForbidIfUnauthorized(Result result)
    // {
    //     return result.IsFailure ? new ForbidResult() : null;
    // }
}
