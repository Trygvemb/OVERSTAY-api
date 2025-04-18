using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Visas.Commands;
using Overstay.Application.Features.Visas.Queries;
using Overstay.Application.Features.Visas.Request;

namespace Overstay.API.Controllers;

public class VisaController(ISender mediator) : MediatorControllerBase(mediator)
{
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetAllVisasQuery(), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetVisaQuery(id), cancellationToken);
        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpPost]
    public async Task<IActionResult> Create(
        CreateVisaCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);

        var visaId = result.GetValue<Guid>();

        return result.IsSuccess
            ? CreatedAtAction(nameof(GetById), new { id = visaId }, visaId)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(
        Guid id,
        UpdateVisaRequest request,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(new UpdateVisaCommand(id, request), cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new DeleteVisaCommand(id), cancellationToken);

        return result.IsSuccess
            ? NoContent()
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }
}
