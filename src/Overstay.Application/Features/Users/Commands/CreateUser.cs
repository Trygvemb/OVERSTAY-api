using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Requests;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Commands;

public sealed record CreateUserCommand(CreateUserRequest Item) : IRequest<Result>;

public class CreateUserCommandHandler(IUserService userService)
    : IRequestHandler<CreateUserCommand, Result>
{
    public async Task<Result> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await userService.CreateAsync(request.Item, cancellationToken);
    }
}
