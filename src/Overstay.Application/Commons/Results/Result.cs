using System.Text.Json.Serialization;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Errors;
using Overstay.Application.Commons.JsonConverters;

namespace Overstay.Application.Commons.Results;

[JsonConverter(typeof(ResultJsonConverterFactory))]
public class Result
{
    public bool IsSuccess { get; }
    public bool IsFailure => !IsSuccess;
    public Error Error { get; }

    protected Result(bool isSuccess, Error error)
    {
        if (isSuccess && error != Error.None || !isSuccess && error == Error.None)
            throw new ArgumentException("Invalid error", nameof(error));

        IsSuccess = isSuccess;
        Error = error;
    }

    public static Result Success() => new Result(true, Error.None);

    public static Result<TValue> Success<TValue>(TValue value) => new(value, true, Error.None);

    public static Result Failure(Error error) => new Result(false, error);

    public static Result<TValue> Failure<TValue>(Error error) =>
        new Result<TValue>(default, false, error);

    public Result<TResult> Map<TResult>(Func<TResult> func)
    {
        return IsSuccess ? Success(func()) : Failure<TResult>(Error);
    }
}

[JsonConverter(typeof(ResultJsonConverterFactory))]
public class Result<TValue> : Result
{
    private readonly TValue? _value;

    protected internal Result(TValue? value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value =>
        IsSuccess
            ? _value!
            : throw new InvalidOperationException("Cannot get value of failed result.");

    public Result<TResult> Map<TResult>(Func<TValue, TResult> mapper)
    {
        return IsSuccess ? Success(mapper(Value)) : Failure<TResult>(Error);
    }

    public Result<TResult> Bind<TResult>(Func<TValue, Result<TResult>> binder)
    {
        return IsSuccess ? binder(Value) : Failure<TResult>(Error);
    }

    public TValue ValueOrDefault(TValue defaultValue) => IsSuccess ? Value : defaultValue;

    public bool TryGetValue(out TValue value)
    {
        value = IsSuccess ? Value : default!;
        return IsSuccess;
    }

    public TResult Match<TResult>(Func<TValue, TResult> onSuccess, Func<Error, TResult> onFailure)
    {
        return IsSuccess ? onSuccess(Value) : onFailure(Error);
    }
}
