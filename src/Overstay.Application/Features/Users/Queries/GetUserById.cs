using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Users.Queries;

public sealed record GetUserByIdQuery(Guid Id) : IRequest<Result<UserResponse>>;

public class GetUserByIdCommandHandler(IUserService userService)
    : IRequestHandler<GetUserByIdQuery, Result<UserResponse>>
{
    public async Task<Result<UserResponse>> Handle(
        GetUserByIdQuery request,
        CancellationToken cancellationToken
    )
    {
        return await userService.GetByIdAsync(request.Id);
    }
}
