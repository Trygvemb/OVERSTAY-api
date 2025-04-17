using System.Text.Json;
using System.Text.Json.Serialization;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Results;

namespace Overstay.Application.Commons.JsonConverters;

// Base converter class for non-generic Result
public class ResultJsonConverter : JsonConverter<Result>
{
    public override bool CanConvert(Type typeToConvert)
    {
        return typeToConvert == typeof(Result)
            || (
                typeToConvert.IsGenericType
                && typeToConvert.GetGenericTypeDefinition() == typeof(Result<>)
            );
    }

    public override Result Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected start of object");
        }

        bool? isSuccess = null;
        Error? error = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException("Expected property name");
            }

            string propertyName = reader.GetString()!;
            reader.Read();

            switch (propertyName)
            {
                case "isSuccess":
                    isSuccess = reader.GetBoolean();
                    break;
                case "error":
                    error = JsonSerializer.Deserialize<Error>(ref reader, options);
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        if (isSuccess == null)
        {
            throw new JsonException("Required property 'isSuccess' not found");
        }

        return isSuccess.Value ? Result.Success() : Result.Failure(error ?? Error.ServerError);
    }

    public override void Write(Utf8JsonWriter writer, Result result, JsonSerializerOptions options)
    {
        writer.WriteStartObject();

        writer.WriteBoolean("isSuccess", result.IsSuccess);

        if (!result.IsSuccess)
        {
            writer.WritePropertyName("error");
            JsonSerializer.Serialize(writer, result.Error, options);
        }

        writer.WriteEndObject();
    }
}

// Generic Result<T> converter
public class ResultJsonConverter<TValue> : JsonConverter<Result<TValue>>
{
    public override Result<TValue> Read(
        ref Utf8JsonReader reader,
        Type typeToConvert,
        JsonSerializerOptions options
    )
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException("Expected start of object");
        }

        bool? isSuccess = null;
        TValue? value = default;
        Error? error = null;

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                break;
            }

            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException("Expected property name");
            }

            var propertyName = reader.GetString()!;
            reader.Read();

            switch (propertyName)
            {
                case "isSuccess":
                    isSuccess = reader.GetBoolean();
                    break;
                case "value":
                    value = JsonSerializer.Deserialize<TValue>(ref reader, options);
                    break;
                case "error":
                    error = JsonSerializer.Deserialize<Error>(ref reader, options);
                    break;
                default:
                    reader.Skip();
                    break;
            }
        }

        if (isSuccess == null)
        {
            throw new JsonException("Required property 'isSuccess' not found");
        }

        return isSuccess.Value
            ? Result.Success(value!)
            : Result.Failure<TValue>(error ?? Error.ServerError);
    }

    public override void Write(
        Utf8JsonWriter writer,
        Result<TValue> result,
        JsonSerializerOptions options
    )
    {
        writer.WriteStartObject();

        writer.WriteBoolean("isSuccess", result.IsSuccess);

        if (result.IsSuccess)
        {
            writer.WritePropertyName("value");
            JsonSerializer.Serialize(writer, result.Value, options);
        }
        else
        {
            writer.WritePropertyName("error");
            JsonSerializer.Serialize(writer, result.Error, options);
        }

        writer.WriteEndObject();
    }
}

// Factory for creating appropriate converters for generic Result<T> types
public class ResultJsonConverterFactory : JsonConverterFactory
{
    public override bool CanConvert(Type typeToConvert)
    {
        if (!typeToConvert.IsGenericType)
        {
            return false;
        }

        return typeToConvert.GetGenericTypeDefinition() == typeof(Result<>);
    }

    public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
    {
        Type valueType = typeToConvert.GetGenericArguments()[0];

        Type converterType = typeof(ResultJsonConverter<>).MakeGenericType(valueType);

        return (JsonConverter)Activator.CreateInstance(converterType)!;
    }
}
