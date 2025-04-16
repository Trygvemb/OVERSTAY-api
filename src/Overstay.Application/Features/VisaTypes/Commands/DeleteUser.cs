using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Commands;

public sealed record DeleteUserCommand(Guid Id) : IRequest<Result>;

public class DeleteUserCommandHandler(IUserService userService)
    : IRequestHandler<DeleteUserCommand, Result>
{
    public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        return await userService.DeleteAsync(request.Id);
    }
}
