using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Visas.Requests;
using Overstay.Application.Services;

namespace Overstay.Application.Features.Visas.Commands;

public sealed record UpdateVisaCommand(Guid Id, UpdateVisaRequest Item) : IRequest<Result>;

public class UpdateVisaCommandHAndler(IVisaService visaService)
    : IRequestHandler<UpdateVisaCommand, Result>
{
    public async Task<Result> Handle(UpdateVisaCommand request, CancellationToken cancellationToken)
    {
        var visa = request.Adapt<Visa>();

        return await visaService.UpdateAsync(visa, cancellationToken);
    }
}
