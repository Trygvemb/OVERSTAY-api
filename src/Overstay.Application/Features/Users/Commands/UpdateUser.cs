using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Requests;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Commands;

public sealed record UpdateUserCommand(UpdateUserRequest Item) : IRequest<Result>;

public class UpdateUserCommandHandler(IUserService userService)
    : IRequestHandler<UpdateUserCommand, Result>
{
    public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        return await userService.UpdateAsync(request.Item, cancellationToken);
    }
}
