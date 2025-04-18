using Overstay.Application.Commons.Results;

namespace Overstay.Application.Services;

public interface IVisaService
{
    Task<Result<List<Visa>>> GetAllAsync(CancellationToken cancellationToken);
    Task<Result<Visa>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<Result<Guid>> CreateAsync(Visa visa, CancellationToken cancellationToken);
    Task<Result> UpdateAsync(Visa visa, CancellationToken cancellationToken);
    Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);
}
