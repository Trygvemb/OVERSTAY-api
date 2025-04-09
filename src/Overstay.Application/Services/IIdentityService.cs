using Overstay.Domain.Entities.Users;

namespace Overstay.Application.Services;

public interface IIdentityService
{
    Task<(bool Succeeded, string Token)> LoginAsync(string userName, string password);
    Task<bool> LogoutAsync();
    Task<User?> GetDomainUserAsync(string userName, CancellationToken cancellationToken);
    Task<(bool Succeeded, string[] Errors)> CreateUserAsync(User domainUser, string password, CancellationToken cancellationToken);
    Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userName, CancellationToken cancellationToken);
    Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(User domainUser, string password, CancellationToken cancellationToken);
    Task<(bool Succeeded, string[] Errors)> UpdateEmailAsync(User domainUser, string email, CancellationToken cancellationToken);
    Task<(bool Succeeded, string[] Errors)> UpdateUserNameAsync(User domainUser, string userName, CancellationToken cancellationToken);
}
