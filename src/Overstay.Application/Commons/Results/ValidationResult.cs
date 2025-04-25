using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Errors;

namespace Overstay.Application.Commons.Results;

public sealed class ValidationResult : Result, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(false, IValidationResult.ValidationError) => Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult WithErrors(Error[] errors) => new(errors);
}

public sealed class ValidationResult<TValue> : Result<TValue>, IValidationResult
{
    private ValidationResult(Error[] errors)
        : base(default, false, IValidationResult.ValidationError) => Errors = errors;

    public Error[] Errors { get; }

    public static ValidationResult<TValue> WithErrors(Error[] errors) => new(errors);
}

public interface IValidationResult
{
    public static readonly Error ValidationError = new(
        ErrorTypeConstants.Validation,
        "A validation error occurred."
    );

    Error[] Errors { get; }
}
