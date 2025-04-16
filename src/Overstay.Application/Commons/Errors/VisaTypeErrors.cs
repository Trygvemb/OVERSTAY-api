namespace Overstay.Application.Commons.Errors;

public static class VisaTypeErrors
{
    public static Error NotFound(Guid id) =>
        new(ErrorTypeConstants.NotFound, $"Visa type with ID {id} not found.");

    public static Error FailedToCreateVisaType =>
        new Error(ErrorTypeConstants.ServerError, "Failed to create visa type.");

    public static Error ConcurrencyError =>
        new Error(
            ErrorTypeConstants.Concurrency,
            "The visa type has been modified by another user. Please reload and try again."
        );
}
