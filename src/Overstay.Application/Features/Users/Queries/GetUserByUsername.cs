using Overstay.Application.Commons.Results;
using Overstay.Application.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Queries;

public sealed record GetUserByUsernameQuery(string Username) : IRequest<Result<UserResponse>>;

public class GetUserByUsernameCommandHandler(IUserService userService)
    : IRequestHandler<GetUserByUsernameQuery, Result<UserResponse>>
{
    public async Task<Result<UserResponse>> Handle(
        GetUserByUsernameQuery request,
        CancellationToken cancellationToken
    )
    {
        return await userService.GetByUsernameAsync(request.Username);
    }
}
