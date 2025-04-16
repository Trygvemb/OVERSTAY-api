using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Commands;

public sealed record UpdateVisaTypeCommand(VisaType VisaType) : IRequest<Result>;

public class UpdateVisaTypeCommandHandler(IVisaTypeService visaTypeService)
    : IRequestHandler<UpdateVisaTypeCommand, Result>
{
    public async Task<Result> Handle(
        UpdateVisaTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        return await visaTypeService.UpdateAsync(
            visaType: request.VisaType,
            cancellationToken: cancellationToken
        );
    }
}
