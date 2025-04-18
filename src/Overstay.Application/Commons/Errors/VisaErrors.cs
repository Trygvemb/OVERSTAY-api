using Overstay.Application.Commons.Constants;

namespace Overstay.Application.Commons.Errors;

public sealed record VisaErrors
{
    public static Error NotFound(Guid id) =>
        new Error(ErrorTypeConstants.NotFound, $"Visa with ID {id} not found.");

    public static Error FailedToCreateVisa =>
        new Error(ErrorTypeConstants.ServerError, "Failed to create visa.");

    public static Error ConcurrencyError =>
        new Error(
            ErrorTypeConstants.Concurrency,
            "The visa has been modified by another user. Please reload and try again."
        );

    public static Error VisaAlreadyExists =>
        new Error(ErrorTypeConstants.Validation, "Visa already exists.");
}
