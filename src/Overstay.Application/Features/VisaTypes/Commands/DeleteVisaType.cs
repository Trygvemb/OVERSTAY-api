using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Commands;

public record DeleteVisaTypeCommand(Guid Id) : IRequest<Result>;

public class DeleteVisaTypeCommandHandler(IVisaTypeService visaTypeService)
    : IRequestHandler<DeleteVisaTypeCommand, Result>
{
    public async Task<Result> Handle(
        DeleteVisaTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        return await visaTypeService.DeleteAsync(request.Id, cancellationToken);
    }
}
