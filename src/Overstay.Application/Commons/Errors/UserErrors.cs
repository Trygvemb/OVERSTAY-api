using Overstay.Application.Commons.Constants;

namespace Overstay.Application.Commons.Errors;

public sealed record UserErrors
{
    public static Error NotFound(string? identifier = null) =>
        new(ErrorTypeConstants.NotFound, $"{identifier} User not found.");

    public static Error ConcurrencyError =>
        new Error(
            ErrorTypeConstants.Concurrency,
            "The user has been modified by another user. Please reload and try again."
        );

    public static Error FailedToCreateUser =>
        new Error(ErrorTypeConstants.ServerError, "Failed to create user.");

    public static Error UserAlreadyExists =>
        new Error(ErrorTypeConstants.Validation, "User already exists.");

    public static Error RetrievingAllUsers =>
        new Error(ErrorTypeConstants.ServerError, "Failed to retrieve all users.");

    public static Error LockedOut =>
        new Error(ErrorTypeConstants.Unauthorized, "User account is locked out.");

    public static Error InvalidCredentials =>
        new Error(ErrorTypeConstants.Unauthorized, "Invalid credentials provided.");

    public static Error SignInFailed =>
        new Error(ErrorTypeConstants.ServerError, "An error occurred during sign in.");

    public static Error UpdateFailed(string? message = null) =>
        new Error(ErrorTypeConstants.ServerError, $"Failed to update user. {message}");

    public static Error DeleteFailed(string? message = null) =>
        new Error(ErrorTypeConstants.ServerError, $"Failed to delete user. {message}");

    public static Error RemoveRoleFailed(string? message = null) =>
        new Error(ErrorTypeConstants.Validation, $"User is not in role {message}.");

    public static Error GetRolesFailed =>
        new Error(ErrorTypeConstants.Validation, "An error occurred while getting user roles.");

    public static Error AccessDenied =>
        new Error(
            ErrorTypeConstants.Forbidden,
            "You dont have permission to access this resource."
        );
}
