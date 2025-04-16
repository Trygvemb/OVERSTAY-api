using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Queries;

public sealed record GetAllUsersQuery() : IRequest<Result<List<UserWithRolesResponse>>>;

public class GetAllUsers(IUserService userService)
    : IRequestHandler<GetAllUsersQuery, Result<List<UserWithRolesResponse>>>
{
    public async Task<Result<List<UserWithRolesResponse>>> Handle(
        GetAllUsersQuery request,
        CancellationToken cancellationToken
    )
    {
        return await userService.GetAllAsync(cancellationToken);
    }
}
