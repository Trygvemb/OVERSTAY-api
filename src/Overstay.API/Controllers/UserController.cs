using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Commands;
using Overstay.Application.Features.Users.Queries;
using Overstay.Application.Features.Users.Responses;
using Overstay.Application.Features.VisaTypes.Commands;

namespace Overstay.API.Controllers;

[AllowAnonymous]
public class UserController(ISender mediator) : MediatorControllerBase(mediator)
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> CreateUser(
        CreateUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);

        if (!result.IsSuccess)
            return StatusCode(GetStatusCode(result.Error.Code), result.Error);

        var userId = result.GetValue<Guid>();

        return CreatedAtAction(nameof(GetById), new { id = userId }, userId);
    }

    [HttpPost("sign-in")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SignInUser(
        SigInUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpPost("sign-out")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> SignOutUser(
        SignOutUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> UpdateUser(
        UpdateUserCommand command,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(command, cancellationToken);

        return result.IsSuccess
            ? Ok(result)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> DeleteUser(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new DeleteUserCommand(id), cancellationToken);
        return result.IsSuccess
            ? NoContent()
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetAllUsersQuery(), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetUserByIdQuery(id), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpGet("by-email/{email}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetByEmail(string email, CancellationToken cancellationToken)
    {
        var result = await Mediator.Send(new GetUserByEmailQuery(email), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }

    [HttpGet("by-username/{username}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<ActionResult> GetByUsername(
        string username,
        CancellationToken cancellationToken
    )
    {
        var result = await Mediator.Send(new GetUserByUsernameQuery(username), cancellationToken);

        return result.IsSuccess
            ? Ok(result.Value)
            : StatusCode(GetStatusCode(result.Error.Code), result.Error);
    }
}
