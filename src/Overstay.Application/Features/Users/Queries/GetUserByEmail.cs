using Overstay.Application.Commons.Results;
using Overstay.Application.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Queries;

public sealed record GetUserByEmailQuery(string Email) : IRequest<Result<UserResponse>>;

public class GetUserByEmailCommandHandler(IUserService userService)
    : IRequestHandler<GetUserByEmailQuery, Result<UserResponse>>
{
    public async Task<Result<UserResponse>> Handle(
        GetUserByEmailQuery request,
        CancellationToken cancellationToken
    )
    {
        return await userService.GetByEmailAsync(request.Email);
    }
}
