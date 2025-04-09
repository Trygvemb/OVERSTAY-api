using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Overstay.Application.Services;
using Overstay.Domain.Entities.Users;
using Overstay.Infrastructure.Data.DbContexts;
using Overstay.Infrastructure.Data.Identities;
using Serilog;

namespace Overstay.Infrastructure.Services;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly SignInManager<ApplicationUser> _signInManager;
    private readonly ApplicationDbContext _dbContext;
    private readonly ILogger _logger;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager,
        ApplicationDbContext dbContext,
        ILogger logger
    )
    {
        _userManager = userManager;
        _signInManager = signInManager;
        _dbContext = dbContext;
        _logger = logger;   
    }

    public async Task<(bool Succeeded, string[] Errors)> CreateUserAsync(
        User domainUser,
        string password,
        CancellationToken cancellationToken
    )
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            if (domainUser.Id == Guid.Empty)
            {
                _dbContext.Users.Add(domainUser);
                await _dbContext.SaveChangesAsync(cancellationToken);
            }

            var existingIdentityUser = await _userManager.Users.FirstOrDefaultAsync(u =>
                u.DomainUserId == domainUser.Id,
                cancellationToken
            );

            if (existingIdentityUser != null)
            {
                await transaction.RollbackAsync(cancellationToken);
                return (false, ["User already exists"]);
            }
            
            var identityUser = new ApplicationUser
            {
                UserName = domainUser.UserName?.Value,
                Email = domainUser.Email?.Value,
                DomainUserId = domainUser.Id,
            };

            var result = await _userManager.CreateAsync(identityUser, password);

            if (!result.Succeeded)
            {
                await transaction.RollbackAsync(cancellationToken);
                return (false, result.Errors.Select(e => e.Description).ToArray());
            }

            await transaction.CommitAsync(cancellationToken);
            return (true, []);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            return (false, [ex.Message]);
        }
    }

    public Task<(bool Succeeded, string[] Errors)> DeleteUserAsync(string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public Task<bool> LogoutAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<(bool Succeeded, string[] Errors)> UpdatePasswordAsync(User domainUser, string password, CancellationToken cancellationToken)
    {
        var identityUser = await _userManager.FindByNameAsync(domainUser.UserName.Value);
        if (identityUser == null)
        {
            return (false, ["User not found."]);
        }
        
        var token = await _userManager.GeneratePasswordResetTokenAsync(identityUser);
        
        var result = await _userManager.ResetPasswordAsync(identityUser, token, password);
        
        if (result.Succeeded)
        {
            return (true, []);
        }
        
        return (false, result.Errors.Select(e => e.Description).ToArray());
    }

    public async Task<(bool Succeeded, string[] Errors)> UpdateEmailAsync(User domainUser, string email, CancellationToken cancellationToken)
    {
        await using var transaction = await _dbContext.Database.BeginTransactionAsync(cancellationToken);

        try
        {
            var identityUser = await _userManager.FindByNameAsync(domainUser.UserName.Value);
            if (identityUser == null)
            {
                return (false, ["User not found."]);
            }
    
            var token = await _userManager.GenerateChangeEmailTokenAsync(identityUser, email);
    
            var result = await _userManager.ChangeEmailAsync(identityUser, email, token);
    
            if (result.Succeeded)
            {
                domainUser.Email.Update(email);
                await _dbContext.SaveChangesAsync(cancellationToken);
                
                await transaction.CommitAsync(cancellationToken);
                return (true, []);
            }
    
            return (false, result.Errors.Select(e => e.Description).ToArray());
        }
        catch (Exception e)
        {
            await transaction.RollbackAsync(cancellationToken);
            throw;
        }

    }

    public Task<(bool Succeeded, string[] Errors)> UpdateUserNameAsync(User domainUser, string userName, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
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

        //TODO:
        // Generate JWT token or other authentication token as needed
        // For simplicity, returning a placeholder
        return (true, "authentication_token_here");
    }

    public async Task<User?> GetDomainUserAsync(string userName, CancellationToken cancellationToken)
    {
        var identityUser = await _userManager.FindByNameAsync(userName);
        if (identityUser == null)
            return null;

        return await _dbContext
            .Users.Include(u => u.Country)
            .Include(u => u.Notification)
            .Include(u => u.Visas)
            .FirstOrDefaultAsync(u => u.Id == identityUser.DomainUserId, cancellationToken);
    }
}