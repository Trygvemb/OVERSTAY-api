using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Visas.Response;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Queries;

public sealed record GetAllVisasQuery : IRequest<Result<List<Visa>>>;

public class GetAllVisasCommandHandler(IVisaService visaService)
    : IRequestHandler<GetAllVisasQuery, Result<List<Visa>>>
{
    public async Task<Result<List<Visa>>> Handle(
        GetAllVisasQuery request,
        CancellationToken cancellationToken
    )
    {
        var visas = await visaService.GetAllAsync(cancellationToken);

        if (visas.IsFailure)
            return Result.Failure<List<Visa>>(visas.Error);

        visas.Value.Adapt<VisaResponse>();

        return visas;
    }
}
