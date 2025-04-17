// SameUserOrAdminAuthorizeAttribute.cs

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Overstay.Infrastructure.Data.Identities;

public class SameUserOrAdminAuthorizeAttribute : TypeFilterAttribute
{
    public SameUserOrAdminAuthorizeAttribute()
        : base(typeof(SameUserOrAdminAuthorizeFilter)) { }
}

public class SameUserOrAdminAuthorizeFilter : IAsyncAuthorizationFilter
{
    private readonly IAuthorizationService _authorizationService;

    public SameUserOrAdminAuthorizeFilter(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        if (
            !context.RouteData.Values.TryGetValue("id", out var routeId)
            || !Guid.TryParse(routeId?.ToString(), out var resourceId)
        )
        {
            context.Result = new ForbidResult();
            return;
        }

        var authResult = await _authorizationService.AuthorizeAsync(
            context.HttpContext.User,
            resourceId,
            "SameUserOrAdmin"
        );

        if (!authResult.Succeeded)
        {
            context.Result = new ForbidResult();
        }
    }
}
