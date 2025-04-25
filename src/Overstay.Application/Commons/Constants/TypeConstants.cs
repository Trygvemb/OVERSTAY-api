namespace Overstay.Application.Commons.Constants;

public static class ErrorTypeConstants
{
    public const string None = "None";
    public const string NotFound = "Not Found Error";
    public const string Validation = "Validation Error";
    public const string Concurrency = "Concurrency Error";
    public const string Unauthorized = "Unauthorized Error";
    public const string Forbidden = "Forbidden Error";
    public const string InternalServerError = "Internal Server Error";
    public const string Conflict = "Conflict Error";
}

public static class RoleTypeConstants
{
    public const string Admin = "Admin";
    public const string User = "User";
}
