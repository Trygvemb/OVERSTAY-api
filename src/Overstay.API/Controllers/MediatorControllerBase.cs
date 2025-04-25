using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Errors;
using Overstay.Application.Commons.Results;

namespace Overstay.API.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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

    protected IActionResult HandleFailedResult(Result result)
    {
        if (result.IsSuccess)
            throw new InvalidOperationException("Cannot handle successful result as failed");

        return result switch
        {
            IValidationResult validationResult => BadRequest(
                CreateProblemDetails(
                    "Validation Failed",
                    StatusCodes.Status400BadRequest,
                    result.Error,
                    validationResult.Errors
                )
            ),

            _ when result.Error.Code == ErrorTypeConstants.NotFound => NotFound(
                CreateProblemDetails(
                    "Resource Not Found",
                    StatusCodes.Status404NotFound,
                    result.Error
                )
            ),

            _ when result.Error.Code == ErrorTypeConstants.Unauthorized => Unauthorized(
                CreateProblemDetails(
                    "Unauthorized Access",
                    StatusCodes.Status401Unauthorized,
                    result.Error
                )
            ),

            _ when result.Error.Code == ErrorTypeConstants.Forbidden => StatusCode(
                StatusCodes.Status403Forbidden,
                CreateProblemDetails(
                    "Access Forbidden",
                    StatusCodes.Status403Forbidden,
                    result.Error
                )
            ),

            _ when result.Error.Code == ErrorTypeConstants.Concurrency => StatusCode(
                StatusCodes.Status409Conflict,
                CreateProblemDetails(
                    "Concurrency Conflict",
                    StatusCodes.Status409Conflict,
                    result.Error
                )
            ),

            _ when result.Error.Code == ErrorTypeConstants.Conflict => StatusCode(
                StatusCodes.Status409Conflict,
                CreateProblemDetails(
                    "Resource Conflict",
                    StatusCodes.Status409Conflict,
                    result.Error
                )
            ),

            _ => StatusCode(
                StatusCodes.Status500InternalServerError,
                CreateProblemDetails(
                    "Server Error",
                    StatusCodes.Status500InternalServerError,
                    result.Error
                )
            ),
        };
    }

    private static ProblemDetails CreateProblemDetails(
        string title,
        int statusCode,
        Error error,
        Error[]? errors = null
    ) =>
        new()
        {
            Title = title,
            Type = error.Code,
            Detail = error.Message,
            Status = statusCode,
            Extensions = { { nameof(errors), errors } },
        };
}
