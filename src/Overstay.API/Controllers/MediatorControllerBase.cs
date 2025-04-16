using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Errors;
using Overstay.Application.Commons.Results;

namespace Overstay.API.Controllers;

//[Authorize]
[ApiController]
[Route("api/[controller]")]
public class MediatorControllerBase(ISender mediator) : ControllerBase
{
    protected ISender Mediator { get; } = mediator;

    protected ActionResult<Result> HandleResult<T>(Result<T> result)
    {
        return result.IsSuccess ? Ok(result) : StatusCode(GetStatusCode(result.Error.Code), result);
    }

    protected ActionResult<Result> HandleResult(Result result)
    {
        return result.IsSuccess ? Ok() : StatusCode(GetStatusCode(result.Error.Code), result);
    }

    protected ActionResult<Result<T>> HandleResultWithResponse<T>(Result<T> result)
    {
        return result.IsSuccess ? Ok(result) : StatusCode(GetStatusCode(result.Error.Code), result);
    }

    protected int GetStatusCode(string errorCode)
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
    // protected int GetStatusCode(string errorCode)
    // {
    //     return errorCode switch
    //     {
    //         "NotFound" => StatusCodes.Status404NotFound,
    //         "Validation" => StatusCodes.Status400BadRequest,
    //         "Unauthorized" => StatusCodes.Status401Unauthorized,
    //         "Forbidden" => StatusCodes.Status403Forbidden,
    //         "Concurrency" => StatusCodes.Status409Conflict,
    //         _ => StatusCodes.Status500InternalServerError,
    //     };
    // }
}
