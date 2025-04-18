using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Features.VisaTypes.Commands;
using Overstay.Application.Features.VisaTypes.Queries;
using Overstay.Application.Features.VisaTypes.Request;
using Overstay.Domain.Entities;

namespace Overstay.API.Controllers;

[Authorize(Roles = RoleTypeConstants.Admin)]
public class VisaTypeController(ISender mediator) : MediatorControllerBase(mediator)
{
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

    [HttpGet("{id:guid}")]
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

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateVisaType(
        Guid id,
        UpdateVisaTypeRequest request,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(new UpdateVisaTypeCommand(id, request), cancellationToken);
        return result.IsSuccess ? Ok(result) : StatusCode(GetStatusCode(result.Error.Code), result);
    }

    [HttpDelete("{id:guid}")]
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
}
