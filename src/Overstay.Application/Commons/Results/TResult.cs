using Overstay.Application.Commons.Constants;

namespace Overstay.Application.Commons.Results;

public class Result<TValue> : Result
{
    private readonly TValue _value;

    protected internal Result(TValue value, bool isSuccess, Error error)
        : base(isSuccess, error)
    {
        _value = value;
    }

    public TValue Value =>
        IsSuccess
            ? _value
            : throw new InvalidOperationException("Cannot get value of failed result.");
}
