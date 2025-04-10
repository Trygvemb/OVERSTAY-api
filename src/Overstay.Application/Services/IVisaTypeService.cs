using Overstay.Application.Commons.Results;

namespace Overstay.Application.Services;

public interface IVisaTypeService
{
    Task<Result<List<VisaType>>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<VisaType>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<Guid>> CreateAsync(VisaType visaType, CancellationToken cancellationToken);
    Task<Result> UpdateAsync(VisaType visaType, CancellationToken cancellationToken);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
