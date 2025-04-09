using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Overstay.Domain.Entities.Users;
using Overstay.Infrastructure.Data.DbContexts;
using Overstay.Infrastructure.Data.Identities;

namespace Overstay.Infrastructure.Services;

public class IdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationDbContext _dbContext;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext dbContext
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _dbContext = dbContext;
    }

    public async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(
        User domainUser,
        string password
    )
    {
        using var transaction = await _dbContext.Database.BeginTransactionAsync();

        try
        {
            // First ensure the domain user is saved
            if (domainUser.Id == Guid.Empty)
            {
                _dbContext.Users.Add(domainUser);
                await _dbContext.SaveChangesAsync();
            }

            // Check if an identity user already exists for this domain user
            var existingIdentityUser = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.DomainUserId == domainUser.Id
            );

            if (existingIdentityUser != null)
            {
                await transaction.RollbackAsync();
                return (false, new[] { "User already exists" });
            }

            // Create the identity user
            var identityUser = new ApplicationUser
            {
                UserName = domainUser.UserName?.Value,
                Email = domainUser.Email?.Value,
                DomainUserId = domainUser.Id,
            };

            var result = await _userManager.CreateAsync(identityUser, password);

            if (!result.Succeeded)
            {
                await transaction.RollbackAsync();
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            await transaction.CommitAsync();
            return (true, Array.Empty<string>());
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync();
            return (false, new[] { ex.Message });
        }
    }

    public async Task<(bool Succeeded, string Token)> LoginAsync(string userName, string password)
    {
        var user = await _userManager.FindByNameAsync(userName);
        if (user == null)
        {
            return (false, string.Empty);
        }

        var result = await _signInManager.CheckPasswordSignInAsync(user, password, false);
        if (!result.Succeeded)
        {
            return (false, string.Empty);
        }

        // Generate JWT token or other authentication token as needed
        // For simplicity, returning a placeholder
        return (true, "authentication_token_here");
    }

    public async Task<User?> GetDomainUserAsync(string userName)
    {
        var identityUser = await _userManager.FindByNameAsync(userName);
        if (identityUser == null)
            return null;

        return await _dbContext
            .Users.Include(u => u.Country)
            .Include(u => u.Notification)
            .Include(u => u.Visas)
            .FirstOrDefaultAsync(u => u.Id == identityUser.DomainUserId);
    }
}
