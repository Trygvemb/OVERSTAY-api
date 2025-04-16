using Overstay.Application.Features.Users.Responses;

namespace Overstay.Application.Services;

public interface ITokenService
{
    Task<TokenResponse> GenerateJwtToken(UserWithRolesResponse user);
    bool ValidateToken(string token);
}
