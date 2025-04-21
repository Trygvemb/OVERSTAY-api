using Overstay.Application.Commons.Results;
using Overstay.Application.Features.VisaTypes.Requests;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Commands;

public sealed record CreateVisaTypeCommand(CreateVisaTypeRequest Item) : IRequest<Result<Guid>>;

public class CreateVisaTypeCommandHandler(IVisaTypeService visaTypeService)
    : IRequestHandler<CreateVisaTypeCommand, Result<Guid>>
{
    public async Task<Result<Guid>> Handle(
        CreateVisaTypeCommand request,
        CancellationToken cancellationToken
    )
    {
        var visaType = request.Item.Adapt<VisaType>();

        return await visaTypeService.CreateAsync(visaType, cancellationToken);
    }
}
