using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Requests;
using Overstay.Application.Features.Users.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Commands;

public sealed record SigInUserCommand(SignInUserRequest Item) : IRequest<Result<TokenResponse>>;

public class SignInUserCommandHandler(IUserService userService)
    : IRequestHandler<SigInUserCommand, Result<TokenResponse>>
{
    public async Task<Result<TokenResponse>> Handle(
        SigInUserCommand request,
        CancellationToken cancellationToken
    )
    {
        return await userService.SignInAsync(request.Item);
    }
}
