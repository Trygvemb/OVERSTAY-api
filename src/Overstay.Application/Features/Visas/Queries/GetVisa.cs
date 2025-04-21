using Overstay.Application.Commons.Results;
using Overstay.Application.Responses;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Queries;

public sealed record GetVisaQuery(Guid Id, Guid UserId) : IRequest<Result<Visa>>;

public class GetVisaCommandHandler(IVisaService visaService)
    : IRequestHandler<GetVisaQuery, Result<Visa>>
{
    public async Task<Result<Visa>> Handle(
        GetVisaQuery request,
        CancellationToken cancellationToken
    )
    {
        var visa = await visaService.GetByIdAsync(request.Id, request.UserId, cancellationToken);

        if (visa.IsFailure)
            return Result.Failure<Visa>(visa.Error);

        visa.Adapt<VisaResponse>();
        return visa;
    }
}
