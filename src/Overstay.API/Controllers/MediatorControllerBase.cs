using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Constants;

namespace Overstay.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize(Roles = RoleTypeConstants.User)]
public class MediatorControllerBase(ISender mediator) : ControllerBase
{
    protected ISender Mediator { get; } = mediator;

    protected static int GetStatusCode(string errorCode)
    {
        return errorCode switch
        {
            ErrorTypeConstants.NotFound => StatusCodes.Status404NotFound,
            ErrorTypeConstants.Validation => StatusCodes.Status400BadRequest,
            ErrorTypeConstants.Unauthorized => StatusCodes.Status401Unauthorized,
            ErrorTypeConstants.Forbidden => StatusCodes.Status403Forbidden,
            ErrorTypeConstants.Concurrency => StatusCodes.Status409Conflict,
            _ => StatusCodes.Status500InternalServerError,
        };
    }
}
