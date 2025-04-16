using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Commands;

public sealed record SignOutUserCommand() : IRequest<Result>;

public class SignOutUser(IUserService userService) : IRequestHandler<SignOutUserCommand, Result>
{
    public async Task<Result> Handle(
        SignOutUserCommand request,
        CancellationToken cancellationToken
    )
    {
        return await userService.SignOutAsync();
    }
}
