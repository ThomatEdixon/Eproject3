using BCrypt.Net;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;
using ServiceMarketingSystem.Services;

namespace ServiceMarketingSystem.Services
{
    public class UserService : IUserService
    {
        private readonly DbConnection _Db;

        public UserService(DbConnection _db)
        {
            this._Db = _db;
        }

        public UserRefreshToken AddUserRefreshTokens(UserRefreshToken user)
        {
            _Db.UserRefreshTokens.Add(user);
            return user;
        }

        public void DeleteUserRefreshTokens(string email, string refreshToken)
        {
            UserRefreshToken item = _Db.UserRefreshTokens.FirstOrDefault(
                u => u.Email == email && u.RefreshToken == refreshToken
            );

            if (item != null)
            {
                _Db.UserRefreshTokens.Remove(item);
            }
        }

        public UserRefreshToken GetSavedRefreshTokens(string email, string refreshtoken)
        {
            return _Db.UserRefreshTokens.FirstOrDefault(
                u => u.Email == email && u.RefreshToken == refreshtoken && u.IsActived == true
            );
        }

        public async Task<Employees> IsValidUserAsync(string email, string password)
        {
            var emp = await _Db.Employees.SingleOrDefaultAsync(e => e.EmpEmail == email);
            if (emp is not null)
            {
                if (emp.Password.Length > 0)
                {
                    if (BCrypt.Net.BCrypt.Verify(password, emp.Password))
                    {
                        return emp;
                    }
                }
            }
            return null;
        }

        public int SaveCommit()
        {
            return _Db.SaveChanges();
        }
    }
}
