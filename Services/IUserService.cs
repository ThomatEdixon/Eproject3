using ServiceMarketingSystem.Models;

namespace ServiceMarketingSystem.Services
{
    public interface IUserService
    {
        Task<Employees> IsValidUserAsync(string email, string password);

        UserRefreshToken AddUserRefreshTokens(UserRefreshToken user);

        UserRefreshToken GetSavedRefreshTokens(string email, string refreshtoken);

        void DeleteUserRefreshTokens(string email, string refreshToken);

        int SaveCommit();
    }
}
