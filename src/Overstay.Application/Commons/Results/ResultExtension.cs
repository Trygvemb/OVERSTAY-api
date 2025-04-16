namespace Overstay.Application.Commons.Results;

public static class ResultExtensions
{
    public static TValue GetValue<TValue>(this Result result)
    {
        if (result is not Result<TValue> typedResult)
        {
            throw new InvalidCastException($"Cannot cast result to Result<{typeof(TValue).Name}>");
        }

        if (!result.IsSuccess)
        {
            throw new InvalidOperationException("Cannot get value of failed result.");
        }

        return typedResult.Value;
    }

    public static bool TryGetValue<TValue>(this Result result, out TValue value)
    {
        value = default!;

        if (result is not Result<TValue> typedResult || !result.IsSuccess)
        {
            return false;
        }

        value = typedResult.Value;
        return true;
    }

    public static TValue ValueOrDefault<TValue>(this Result result, TValue defaultValue)
    {
        if (result is not Result<TValue> typedResult || !result.IsSuccess)
        {
            return defaultValue;
        }

        return typedResult.Value;
    }
}
