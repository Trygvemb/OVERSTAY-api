using Overstay.Application.Commons.Results;
using Overstay.Application.Features.VisaTypes.Request;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Commands;

public sealed record CreateVisaTypeCommand(CreateVisaTypeRequest Item) : IRequest<Result>;

public class CreateVisaTypeCommandHandler(IVisaTypeService visaTypeService)
    : IRequestHandler<CreateVisaTypeCommand, Result>
{
    public async Task<Result> Handle(
        CreateVisaTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        var visaType = request.Item.Adapt<VisaType>();

        return await visaTypeService.CreateAsync(visaType, cancellationToken);
    }
}
