using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Visas.Request;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Commands;

public sealed record CreateVisaCommand(Guid UserId, CreateVisaRequest Item) : IRequest<Result>;

public class CreateVisaCommandHAndler(IVisaService visaService)
    : IRequestHandler<CreateVisaCommand, Result>
{
    public async Task<Result> Handle(CreateVisaCommand request, CancellationToken cancellationToken)
    {
        var visa = request.Item.Adapt<Visa>();
        visa.UserId = request.UserId;

        return await visaService.CreateAsync(visa, cancellationToken);
    }
}
