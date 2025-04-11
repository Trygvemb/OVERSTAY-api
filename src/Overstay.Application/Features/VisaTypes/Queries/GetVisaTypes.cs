using Overstay.Application.Commons.Results;
using Overstay.Application.Services;

namespace Overstay.Application.Features.VisaTypes.Queries;

public record GetVisaTypesQuery : IRequest<Result<List<VisaType>>>;

public class GetVisaTypesCommandHandler(IVisaTypeService visaTypeService) : IRequestHandler<GetVisaTypesQuery, Result<List<VisaType>>>
{
    public async Task<Result<List<VisaType>>> Handle(GetVisaTypesQuery request, CancellationToken cancellationToken)
    {
        return await visaTypeService.GetAllAsync(cancellationToken);
    }
    
}
