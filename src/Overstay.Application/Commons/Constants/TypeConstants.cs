namespace Overstay.Application.Commons.Errors;

public static class ErrorTypeConstants
{
    public const string None = "None";
    public const string NotFound = "NotFound";
    public const string Validation = "Validation";
    public const string Concurrency = "Concurrency";
    public const string ServerError = "ServerError";
    public const string Unauthorized = "Unauthorized";
    public const string Forbidden = "Forbidden";
    public const string InternalServerError = "InternalServerError";
}

public static class RoleTypeConstants
{
    public const string Admin = "Admin";
    public const string User = "User";
}
