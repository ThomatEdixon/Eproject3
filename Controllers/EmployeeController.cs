using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;
using ServiceMarketingSystem.Services;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceMarketingSystem.Controllers
{
    [ApiController]
    [Route("/Service/[Controller]/[Action]")]
    public class EmployeeController : ControllerBase
    {
        private readonly DbConnection _Db;
        private readonly IJWTManagerService jWTManager;
        private readonly IUserService userService;
        public EmployeeController(DbConnection db, IJWTManagerService jWTManager,
        IUserService userService)
        {
            _Db = db;
            this.jWTManager = jWTManager;
            this.userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] Employees newEmployee)
        {
            bool existedEmail = await _Db.Employees.AnyAsync(e => e.EmpEmail.Equals(newEmployee.EmpEmail));
            int count = 0;
            foreach (var r in _Db.Roles)
            {
                if (newEmployee.RoleId == r.Id)
                {
                    count++;
                }

            }
            if (count == 0)
            {
                ModelState.AddModelError("Role not found", "Role not found");
                return Ok();
            }
            Employees employee = new Employees();
            employee.EmpName = newEmployee.EmpName;
            employee.EmpEmail = newEmployee.EmpEmail;
            employee.EmpPhone = newEmployee.EmpPhone;
            employee.EmpAddress = newEmployee.EmpAddress;
            employee.Dob = newEmployee.Dob;
            employee.StoreId = newEmployee.StoreId;
            employee.RoleId = newEmployee.RoleId;
            employee.Password = BCrypt.Net.BCrypt.HashPassword(newEmployee.Password);
            if (!existedEmail)
            {
                await _Db.Employees.AddAsync(employee);
                await _Db.SaveChangesAsync();
            }
            return Ok(newEmployee);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Employees employee)
        {
            var validEmp = await userService.IsValidUserAsync(employee.EmpEmail, employee.Password);
            if (validEmp is null)
            {
                return Unauthorized(new { Message = "Incorrect username or password!" });
            }
            var token = jWTManager.GenerateToken(employee.EmpEmail);
            if (token is null)
            {
                return Unauthorized(new { Message = "Invalid Attempt!" });
            }
            UserRefreshToken rfToken = new UserRefreshToken()
            {
                RefreshToken = token.RefreshToken,
                Email = validEmp.EmpEmail,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(24)
            };

            userService.AddUserRefreshTokens(rfToken);
            userService.SaveCommit();

            var userInfo = new Employees()
            {
                Id = validEmp.Id,
                EmpEmail = validEmp.EmpEmail,
                EmpName = validEmp.EmpName,
                EmpPhone = validEmp.EmpPhone,
                EmpAddress = validEmp.EmpAddress,
                Dob = validEmp.Dob,
                
            };
            return Ok(new { token, userInfo });
        }
        [HttpPost]
        public IActionResult Refresh(Tokens token)
        {
            var principal = jWTManager.GetPrincipalFromExpiredToken(token.AccessToken);
            var username = principal.Identity?.Name;
            var role = principal.Claims.ToArray()[4].Value;
            var savedRefreshToken = userService.GetSavedRefreshTokens(username, token.RefreshToken);

            if (
                savedRefreshToken?.RefreshToken != token.RefreshToken
                || savedRefreshToken?.RefreshTokenExpiryTime <= DateTime.UtcNow
            )
            {
                return Unauthorized(new { Message = "Invalid attempt!" });
            }

            var newJwtToken = jWTManager.GenerateRefreshToken(username);

            if (newJwtToken == null)
            {
                return Unauthorized(new { Message = "Invalid attempt!" });
            }

            UserRefreshToken rfToken = new UserRefreshToken
            {
                RefreshToken = newJwtToken.RefreshToken,
                Email = username,
                RefreshTokenExpiryTime = DateTime.UtcNow.AddHours(24)
            };

            userService.DeleteUserRefreshTokens(username, token.RefreshToken);
            userService.AddUserRefreshTokens(rfToken);
            userService.SaveCommit();

            return Ok(newJwtToken);
        }
        [HttpGet]
        public async Task<IActionResult> GetListSlug(int roleId)
        {
            List<Slug> slugs = new List<Slug>();
            foreach(var s in _Db.Slug)
            {
                if(s.RoleId == roleId)
                {
                    slugs.Add(s);
                }
            }
            if(slugs.Count < 0) {
                return NotFound();
            }
            return Ok(slugs);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByName(string name)
        {
            Employees? employee = await _Db.Employees.SingleOrDefaultAsync(e=>e.EmpName.Equals(name));
            if(employee is null) {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployeeByEmail(string email)
        {
            Employees? employee = await _Db.Employees.SingleOrDefaultAsync(e => e.EmpEmail.Equals(email));
            if (employee is null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
    }
}
