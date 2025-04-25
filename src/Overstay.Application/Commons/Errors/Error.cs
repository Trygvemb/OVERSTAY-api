using Overstay.Application.Commons.Constants;

namespace Overstay.Application.Commons.Errors;

public sealed record Error(string Code, string? Message = null)
{
    internal static Error None => new(ErrorTypeConstants.None);

    public static Error ServerError =>
        new Error(
            ErrorTypeConstants.InternalServerError,
            "Operation failed due to a server error."
        );
}
