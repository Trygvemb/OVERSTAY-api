using Overstay.Application.Commons.Results;
using Overstay.Application.Features.Users.Requests;
using Overstay.Application.Features.Users.Responses;

namespace Overstay.Application.Services;

public interface IUserService
{
    // Users section
    public Task<Result> SignInAsync(SignInUserRequest request, CancellationToken cancellationToken);

    public Task<Result<List<UserWithRolesResponse>>> GetAllAsync(
        CancellationToken cancellationToken
    );
    public Task<Result<UserResponse>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    public Task<Result<UserResponse>> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken
    );
    public Task<Result<UserResponse>> GetByUsernameAsync(
        string username,
        CancellationToken cancellationToken
    );

    public Task<Result<Guid>> CreateAsync(
        CreateUserRequest request,
        CancellationToken cancellationToken
    );
    public Task<Result<UserResponse>> UpdateAsync(
        Guid id,
        UpdateUserRequest request,
        CancellationToken cancellationToken
    );
    public Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken);

    public Task<Result<bool>> IsEmailUniqueAsync(string email, CancellationToken cancellationToken);
    public Task<Result<bool>> IsUsernameUniqueAsync(
        string username,
        CancellationToken cancellationToken
    );

    // Users Roles section
    public Task<Result<UserWithRolesResponse>> AddRoleAsync(
        Guid userId,
        string roleName,
        CancellationToken cancellationToken
    );
    public Task<Result> RemoveRoleAsync(
        Guid userId,
        string roleName,
        CancellationToken cancellationToken
    );
    public Task<Result<List<string>>> GetUserRolesAsync(
        Guid userId,
        CancellationToken cancellationToken
    );
}
