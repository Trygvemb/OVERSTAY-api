using Overstay.Application.Commons.Results;
using Overstay.Application.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Queries;

public sealed record GetAllVisasQuery(Guid UserId) : IRequest<Result<List<Visa>>>;

public class GetAllVisasCommandHandler(IVisaService visaService)
    : IRequestHandler<GetAllVisasQuery, Result<List<Visa>>>
{
    public async Task<Result<List<Visa>>> Handle(
        GetAllVisasQuery request,
        CancellationToken cancellationToken
    )
    {
        var visas = await visaService.GetAllAsync(request.UserId, cancellationToken);

        if (visas.IsFailure)
            return Result.Failure<List<Visa>>(visas.Error);

        visas.Value.Adapt<VisaResponse>();
        return visas;
    }
}
