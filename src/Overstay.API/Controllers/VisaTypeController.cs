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
    public async Task<ActionResult<Result<List<VisaType>>>> GetVisaTypes(CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetVisaTypesQuery(), cancellationToken);
    }
    
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result<VisaType>>> GetVisaTypeById(Guid id, CancellationToken cancellationToken)
    {
        return await Mediator.Send(new GetVisaTypeQuery(id), cancellationToken);
    }
    
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> CreateVisaType(CreateVisaTypeCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> UpdateVisaType(Guid id, UpdateVisaTypeCommand command, CancellationToken cancellationToken)
    {
        return await Mediator.Send(command, cancellationToken);
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult<Result>> DeleteVisaType(Guid id, CancellationToken cancellationToken)
    {
        return await Mediator.Send(new DeleteVisaTypeCommand(id), cancellationToken);
    }
    
}