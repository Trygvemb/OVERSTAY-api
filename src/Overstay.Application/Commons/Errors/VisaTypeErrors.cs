namespace Overstay.Application.Commons.Errors;

public class VisaTypeErrors
{
    public static Error NotFound(Guid id) =>
        new(ErrorTypeConstants.NotFound, $"Visa type with ID {id} not found.");

    public static Error ServerError =>
        new Error(ErrorTypeConstants.ServerError, "Operation failed due to a server error.");

    public static Error ConcurrencyError =>
        new Error(
            ErrorTypeConstants.Concurrency,
            "The visa type has been modified by another user. Please reload and try again."
        );

    public static Error ServError =>
        new Error(
            ErrorTypeConstants.ServerError,
            "Failed to retrieve visa types due to a server error."
        );
}
