using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Overstay.Application.Responses;
using Overstay.Application.Services;

namespace Overstay.Infrastructure.Services;

public class TokenService(IConfiguration configuration, ILogger<TokenService> logger)
    : ITokenService
{
    public Task<TokenResponse> GenerateJwtToken(UserWithRolesResponse user)
    {
        logger.LogInformation("Generating JWT token for user {UserId}", user.Id);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new(ClaimTypes.Name, user.UserName),
            new(ClaimTypes.Email, user.Email),
        };

        claims.AddRange(user.Roles.Select(role => new Claim(ClaimTypes.Role, role)));
        logger.LogDebug("Added {ClaimsCount} claims to token", claims.Count);

        var key = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(
                configuration["JwtSettings:SecretKey"] ?? throw new InvalidOperationException()
            )
        );
        var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var expires = DateTime.Now.AddMinutes(
            int.Parse(configuration["JwtSettings:ExpirationMinutes"] ?? "30")
        );

        var token = new JwtSecurityToken(
            issuer: configuration["JwtSettings:Issuer"],
            audience: configuration["JwtSettings:Audience"],
            claims: claims,
            expires: expires,
            signingCredentials: signingCredentials
        );

        var tokenResponse = new TokenResponse
        {
            AccessToken = new JwtSecurityTokenHandler().WriteToken(token),
            ExpiresAt = expires,
        };

        logger.LogInformation("Successfully generated JWT token for user {UserId}", user.Id);
        return Task.FromResult(tokenResponse);
    }

    public bool ValidateToken(string token)
    {
        logger.LogInformation("Validating JWT token");

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(
            configuration["JwtSettings:SecretKey"] ?? throw new InvalidOperationException()
        );

        try
        {
            tokenHandler.ValidateToken(
                token,
                new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = configuration["JwtSettings:Issuer"],
                    ValidAudience = configuration["JwtSettings:Audience"],
                    ClockSkew = TimeSpan.Zero,
                },
                out _
            );

            logger.LogInformation("JWT token validation successful");
            return true;
        }
        catch (Exception ex)
        {
            logger.LogWarning(ex, "JWT token validation failed");
            return false;
        }
    }
}
