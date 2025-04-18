using MapsterMapper;
using Microsoft.AspNetCore.Identity;
using Overstay.Application.Commons.Constants;
using Overstay.Application.Commons.Errors;
using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Requests;
using Overstay.Application.Features.Users.Responses;
using Overstay.Application.Services;
using Overstay.Infrastructure.Data.DbContexts;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Services;

public class UserService(
    ApplicationDbContext context,
    UserManager<ApplicationUser> userManager,
    SignInManager<ApplicationUser> signInManager,
    ITokenService tokenService,
    ILogger<UserService> logger,
    IMapper mapper
) : IUserService
{
    public async Task<Result<TokenResponse>> SignInAsync(SignInUserRequest request)
    {
        try
        {
            var user = await userManager.FindByNameAsync(request.UserName);
            if (user is null)
            {
                logger.LogWarning("User with username {Username} not found", request.UserName);
                return Result.Failure<TokenResponse>(UserErrors.NotFound(request.UserName));
            }

            var signInResult = await signInManager.PasswordSignInAsync(
                user,
                request.Password,
                isPersistent: false,
                lockoutOnFailure: true
            );

            if (!signInResult.Succeeded)
            {
                logger.LogWarning("Failed to sign in user {Username}", request.UserName);

                return Result.Failure<TokenResponse>(
                    signInResult.IsLockedOut ? UserErrors.LockedOut : UserErrors.InvalidCredentials
                );
            }

            var roles = await userManager.GetRolesAsync(user);
            var userInfo = new UserWithRolesResponse
            {
                Id = user.Id,
                UserName = user.UserName!,
                Email = user.Email!,
                Roles = roles.ToList(),
            };

            var tokenResponse = await tokenService.GenerateJwtToken(userInfo);

            logger.LogInformation("User {Username} signed in successfully", request.UserName);
            return Result.Success(tokenResponse);
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error occurred while signing in user {Username}",
                request.UserName
            );
            return Result.Failure<TokenResponse>(UserErrors.SignInFailed);
        }
    }

    public async Task<Result> SignOutAsync()
    {
        try
        {
            await signInManager.SignOutAsync();

            logger.LogInformation("User signed out successfully");
            return Result.Success();
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error SigningOut");
            return Result.Failure(Error.ServerError);
        }
    }

    public async Task<Result<List<UserWithRolesResponse>>> GetAllAsync(
        CancellationToken cancellationToken
    )
    {
        try
        {
            var users = await userManager.Users.ToListAsync(cancellationToken);
            var userWithRolesResponses = new List<UserWithRolesResponse>();

            foreach (var user in users)
            {
                var roles = await userManager.GetRolesAsync(user);

                userWithRolesResponses.Add(
                    new UserWithRolesResponse
                    {
                        Id = user.Id,
                        UserName = user.UserName!,
                        Email = user.Email!,
                        Roles = roles.ToList(),
                    }
                );
            }

            return userWithRolesResponses.Count != 0
                ? Result.Success(userWithRolesResponses)
                : Result.Failure<List<UserWithRolesResponse>>(UserErrors.NotFound());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error retrieving all users");
            return Result.Failure<List<UserWithRolesResponse>>(UserErrors.RetrievingAllUsers);
        }
    }

    public async Task<Result<UserResponse>> GetByIdAsync(Guid id)
    {
        var applicationUser = await userManager.FindByIdAsync(id.ToString());
        if (applicationUser is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(id.ToString()));
        }

        var response = new UserResponse
        {
            Id = applicationUser.Id,
            UserName = applicationUser.UserName!,
            Email = applicationUser.Email!,
        };

        return Result.Success(response);
    }

    public async Task<Result<UserResponse>> GetByEmailAsync(string email)
    {
        var applicationUser = await userManager.FindByEmailAsync(email);
        if (applicationUser is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(email));
        }

        var response = new UserResponse
        {
            Id = applicationUser.Id,
            UserName = applicationUser.UserName!,
            Email = applicationUser.Email!,
        };

        return Result.Success(response);
    }

    public async Task<Result<UserResponse>> GetByUsernameAsync(string username)
    {
        var applicationUser = await userManager.FindByNameAsync(username);
        if (applicationUser is null)
        {
            return Result.Failure<UserResponse>(UserErrors.NotFound(username));
        }

        var response = new UserResponse
        {
            Id = applicationUser.Id,
            UserName = applicationUser.UserName!,
            Email = applicationUser.Email!,
        };

        return Result.Success(response);
    }

    public async Task<Result<Guid>> CreateAsync(
        CreateUserRequest request,
        CancellationToken cancellationToken
    )
    {
        var existingUser = await userManager.FindByEmailAsync(request.Email);
        if (existingUser is not null)
        {
            return Result.Failure<Guid>(UserErrors.UserAlreadyExists);
        }

        var strategy = context.Database.CreateExecutionStrategy();

        // Using strategy to wrap the transaction in since EF Core is configured to use retry on failure
        return await strategy.ExecuteAsync(async () =>
        {
            await using var transaction = await context.Database.BeginTransactionAsync(
                cancellationToken
            );

            try
            {
                var applicationUser = new ApplicationUser
                {
                    Id = Guid.NewGuid(),
                    UserName = request.UserName,
                    Email = request.Email,
                };

                var identityResult = await userManager.CreateAsync(
                    applicationUser,
                    request.Password
                );
                if (!identityResult.Succeeded)
                {
                    return Result.Failure<Guid>(
                        new Error(identityResult.Errors.First().Description)
                    );
                }

                await userManager.AddToRoleAsync(applicationUser, RoleTypeConstants.User);

                var user = new User(countryId: request.CountryId) { Id = applicationUser.Id };

                await context.AddAsync(user, cancellationToken);
                await context.SaveChangesAsync(cancellationToken);

                await transaction.CommitAsync(cancellationToken);
                return Result.Success(applicationUser.Id);
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync(cancellationToken);

                logger.LogError(ex, "Error creating user, rolling back transaction.");
                return Result.Failure<Guid>(UserErrors.FailedToCreateUser);
            }
        });
    }

    public async Task<Result> UpdateAsync(
        Guid id,
        UpdateUserRequest request,
        CancellationToken cancellationToken
    )
    {
        try
        {
            var applicationUser = await userManager.FindByIdAsync(id.ToString());
            if (applicationUser is null)
            {
                return Result.Failure<UserResponse>(UserErrors.NotFound(id.ToString()));
            }

            mapper.Map(request, applicationUser);

            var updateResult = await userManager.UpdateAsync(applicationUser);
            if (!updateResult.Succeeded)
            {
                logger.LogWarning("failed to update user {id}:", id);
                return Result.Failure<UserResponse>(
                    UserErrors.UpdateFailed(updateResult.Errors.First().Description)
                );
            }

            if (!string.IsNullOrEmpty(request.Password))
            {
                var removePasswordResult = await userManager.RemovePasswordAsync(applicationUser);
                if (!removePasswordResult.Succeeded)
                {
                    logger.LogWarning("failed to remove password:");
                    return Result.Failure<UserResponse>(
                        UserErrors.UpdateFailed(updateResult.Errors.First().Description)
                    );
                }

                var addPasswordResult = await userManager.AddPasswordAsync(
                    applicationUser,
                    request.Password
                );
                if (!addPasswordResult.Succeeded)
                {
                    logger.LogWarning("failed to add password:");
                    return Result.Failure<UserResponse>(
                        UserErrors.UpdateFailed(updateResult.Errors.First().Description)
                    );
                }

                logger.LogInformation("Password updated successfully");
            }

            var response = new UserResponse
            {
                Id = applicationUser.Id,
                UserName = applicationUser.UserName!,
                Email = applicationUser.Email!,
            };

            return Result.Success(response);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while updating user with ID {UserId}", id);
            return Result.Failure<UserResponse>(UserErrors.UpdateFailed());
        }
    }

    public async Task<Result> DeleteAsync(Guid id)
    {
        try
        {
            var applicationUser = await userManager.FindByIdAsync(id.ToString());
            if (applicationUser is null)
            {
                return Result.Failure(UserErrors.NotFound(id.ToString()));
            }

            var result = await userManager.DeleteAsync(applicationUser);

            return result.Succeeded
                ? Result.Success()
                : Result.Failure(UserErrors.DeleteFailed(result.Errors.First().Description));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Error occurred while deleting user with ID {UserId}", id);
            return Result.Failure(UserErrors.DeleteFailed());
        }
    }

    public async Task<Result<bool>> IsEmailUniqueAsync(string email)
    {
        var existingUser = await userManager.FindByEmailAsync(email);

        return existingUser is null
            ? Result.Success(true)
            : Result.Failure<bool>(UserErrors.UserAlreadyExists);
    }

    public async Task<Result<bool>> IsUsernameUniqueAsync(string username)
    {
        var existingUser = await userManager.FindByNameAsync(username);

        return existingUser is null
            ? Result.Success(true)
            : Result.Failure<bool>(UserErrors.UserAlreadyExists);
    }

    public async Task<Result<UserWithRolesResponse>> AddRoleAsync(Guid userId, string roleName)
    {
        var user = await userManager.FindByIdAsync(userId.ToString());

        if (user is null)
        {
            return Result.Failure<UserWithRolesResponse>(UserErrors.NotFound(userId.ToString()));
        }

        var result = await userManager.AddToRoleAsync(user, roleName);

        if (!result.Succeeded)
        {
            return Result.Failure<UserWithRolesResponse>(
                UserErrors.UpdateFailed(result.Errors.First().Description)
            );
        }

        var roles = await userManager.GetRolesAsync(user);

        var userWithRolesResponse = new UserWithRolesResponse
        {
            Id = user.Id,
            UserName = user.UserName!,
            Email = user.Email!,
            Roles = roles.ToList(),
        };

        return Result.Success(userWithRolesResponse);
    }

    public async Task<Result> RemoveRoleAsync(Guid userId, string roleName)
    {
        try
        {
            var user = await userManager.FindByIdAsync(userId.ToString());

            if (user is null)
            {
                return Result.Failure(UserErrors.NotFound(userId.ToString()));
            }

            var isInRole = await userManager.IsInRoleAsync(user, roleName);
            if (!isInRole)
            {
                return Result.Failure(UserErrors.RemoveRoleFailed(roleName));
            }

            var result = await userManager.RemoveFromRoleAsync(user, roleName);

            if (!result.Succeeded)
            {
                logger.LogError(
                    "Failed to remove role {RoleName} from user {UserId}: {Errors}",
                    roleName,
                    userId,
                    result.Errors.First().Description
                );

                return Result.Failure(UserErrors.UpdateFailed(result.Errors.First().Description));
            }

            logger.LogInformation(
                "Successfully removed role {RoleName} from user {UserId}",
                roleName,
                userId
            );

            return Result.Success();
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "An error occurred while removing role {RoleName} from user {UserId}",
                roleName,
                userId
            );
            return Result.Failure(UserErrors.UpdateFailed());
        }
    }

    public async Task<Result<List<string>>> GetUserRolesAsync(Guid userId)
    {
        try
        {
            var applicationUser = await userManager.FindByIdAsync(userId.ToString());
            if (applicationUser is null)
            {
                return Result.Failure<List<string>>(UserErrors.NotFound(userId.ToString()));
            }

            var roles = await userManager.GetRolesAsync(applicationUser);
            return Result.Success(roles.ToList());
        }
        catch (Exception ex)
        {
            logger.LogError(
                ex,
                "Error occurred while getting user roles for user with id '{UserId}'",
                userId
            );
            return Result.Failure<List<string>>(UserErrors.GetRolesFailed);
        }
    }
}
