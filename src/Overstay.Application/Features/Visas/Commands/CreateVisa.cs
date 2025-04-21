using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Visas.Requests;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Commands;

public sealed record CreateVisaCommand(CreateVisaRequest Item, Guid UserId) : IRequest<Result>;

public class CreateVisaCommandHandler(IVisaService visaService)
    : IRequestHandler<CreateVisaCommand, Result>
{
    public async Task<Result> Handle(CreateVisaCommand request, CancellationToken cancellationToken)
    {
        var visa = request.Item.Adapt<Visa>();
        visa.UserId = request.UserId;

        return await visaService.CreateAsync(visa, cancellationToken);
    }
}
