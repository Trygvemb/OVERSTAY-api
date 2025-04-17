using MapsterMapper;
using Microsoft.Extensions.Logging;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Results;
using Overstay.Application.Services;
using Overstay.Infrastructure.Data.DbContexts;

namespace Overstay.Infrastructure.Services;

public class VisaTypeService(
    ApplicationDbContext context,
    ILogger<VisaTypeService> logger,
    IMapper mapper
) : IVisaTypeService
{
    public async Task<Result<List<VisaType>>> GetAllAsync(CancellationToken cancellationToken)
    {
        try
        {
            var visaTypes = await context.VisaTypes.ToListAsync(cancellationToken);
            return Result.Success(visaTypes);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while retrieving all visa types");
            return Result.Failure<List<VisaType>>(Error.ServerError);
        }
    }

    public async Task<Result<VisaType>> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var visaType = await context.VisaTypes.FindAsync([id], cancellationToken);

            if (visaType is not null)
                return Result.Success(visaType);

            logger.LogWarning("Visa type with ID {Id} not found", id);
            return Result.Failure<VisaType>(VisaTypeErrors.NotFound(id));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while retrieving visa type with ID {Id}", id);
            return Result.Failure<VisaType>(Error.ServerError);
        }
    }

    public async Task<Result<Guid>> CreateAsync(
        VisaType visaType,
        CancellationToken cancellationToken
    )
    {
        try
        {
            await context.VisaTypes.AddAsync(visaType, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Created visa type with ID {Id}", visaType.Id);
            return Result.Success(visaType.Id);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while creating visa type");
            return Result.Failure<Guid>(Error.ServerError);
        }
    }

    public async Task<Result> UpdateAsync(VisaType visaType, CancellationToken cancellationToken)
    {
        try
        {
            var existingVisaType = await context.VisaTypes.FindAsync(
                [visaType.Id],
                cancellationToken
            );

            if (existingVisaType is null)
            {
                logger.LogWarning("Cannot update: Visa type with ID {Id} not found", visaType.Id);
                return Result.Failure(VisaTypeErrors.NotFound(visaType.Id));
            }

            mapper.Map(visaType, existingVisaType);

            context.VisaTypes.Update(existingVisaType);
            await context.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Updated visa type with ID {Id}", visaType.Id);
            return Result.Success();
        }
        catch (DbUpdateConcurrencyException ex)
        {
            logger.LogWarning(
                ex,
                "Concurrency conflict when updating visa type with ID {Id}",
                visaType.Id
            );
            return Result.Failure(VisaTypeErrors.ConcurrencyError);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error occurred while updating visa type with ID {Id}",
                visaType.Id
            );
            return Result.Failure(Error.ServerError);
        }
    }

    public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var visaType = await context.VisaTypes.FindAsync([id], cancellationToken);

            if (visaType is null)
            {
                logger.LogWarning("Cannot delete: Visa type with ID {Id} not found", id);
                return Result.Failure(VisaTypeErrors.NotFound(id));
            }

            context.VisaTypes.Remove(visaType);
            await context.SaveChangesAsync(cancellationToken);

            logger.LogInformation("Deleted visa type with ID {Id}", id);
            return Result.Success();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while deleting visa type with ID {Id}", id);
            return Result.Failure(Error.ServerError);
        }
    }
}
