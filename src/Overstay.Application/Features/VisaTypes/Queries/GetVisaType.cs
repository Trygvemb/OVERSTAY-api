using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Queries;

public sealed record GetVisaTypeQuery(Guid Id) : IRequest<Result<VisaType>>;

public class GetVisaTypeCommandHandler(IVisaTypeService visaTypeService)
    : IRequestHandler<GetVisaTypeQuery, Result<VisaType>>
{
    public async Task<Result<VisaType>> Handle(
        GetVisaTypeQuery request,
        CancellationToken cancellationToken
    )
    {
        return await visaTypeService.GetByIdAsync(request.Id, cancellationToken);
    }
}
