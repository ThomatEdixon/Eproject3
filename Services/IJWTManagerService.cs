using System.Security.Claims;
using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Services
{
    public interface IJWTManagerService
    {
        Tokens GenerateToken(string email);
        Tokens GenerateRefreshToken(string email);
        ClaimsPrincipal GetPrincipalFromExpiredToken(string token);
    }
}
