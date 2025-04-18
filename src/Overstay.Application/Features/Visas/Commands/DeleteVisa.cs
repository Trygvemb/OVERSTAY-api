using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Commands;

public sealed record DeleteVisaCommand(Guid Id) : IRequest<Result>;

public class DeleteVisaCommandHandler(IVisaService visaService)
    : IRequestHandler<DeleteVisaCommand, Result>
{
    public Task<Result> Handle(DeleteVisaCommand request, CancellationToken cancellationToken)
    {
        return visaService.DeleteAsync(request.Id, cancellationToken);
    }
}
