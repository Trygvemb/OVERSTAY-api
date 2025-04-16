using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Results;
using Overstay.Application.Features.VisaTypes.Commands;
using Overstay.Application.Features.VisaTypes.Queries;
using Overstay.Domain.Entities;

namespace Overstay.API.Controllers;

[AllowAnonymous]
public class VisaTypeController(ISender mediator) : MediatorControllerBase(mediator)
{
    //[Authorize]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<List<VisaType>>> GetVisaTypes(
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(new GetVisaTypesQuery(), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<VisaType>> GetVisaTypeById(
        Guid id,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(new GetVisaTypeQuery(id), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateVisaType(
        CreateVisaTypeCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);
        return result.IsSuccess ? Ok() : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateVisaType(
        Guid id,
        UpdateVisaTypeCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);
        return result.IsSuccess ? Ok() : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteVisaType(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new DeleteVisaTypeCommand(id), cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
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
