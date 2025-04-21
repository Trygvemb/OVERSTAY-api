using Overstay.Application.Commons.Results;
using Overstay.Application.Features.VisaTypes.Requests;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Commands;

public sealed record UpdateVisaTypeCommand(Guid Id, UpdateVisaTypeRequest Item) : IRequest<Result>;

public class UpdateVisaTypeCommandHandler(IVisaTypeService visaTypeService)
    : IRequestHandler<UpdateVisaTypeCommand, Result>
{
    public async Task<Result> Handle(
        UpdateVisaTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        var visaType = request.Adapt<VisaType>();

        return await visaTypeService.UpdateAsync(visaType, cancellationToken: cancellationToken);
    }
}
