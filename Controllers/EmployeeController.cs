using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;
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
        private readonly IConfiguration configuaration;
        public EmployeeController(DbConnection db, IConfiguration configuaration)
        {
            _Db = db;
            this.configuaration = configuaration;
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
            if(!existedEmail)
            {
                employee.EmpName = newEmployee.EmpName;
                employee.EmpEmail = newEmployee.EmpEmail;
                employee.EmpPhone = newEmployee.EmpPhone;
                employee.EmpAddress = newEmployee.EmpAddress;
                employee.Dob = newEmployee.Dob;
                employee.StoreId = newEmployee.StoreId;
                employee.RoleId = newEmployee.RoleId;
                employee.Password = BCrypt.Net.BCrypt.HashPassword(newEmployee.Password);
                await _Db.Employees.AddAsync(employee);
                await _Db.SaveChangesAsync();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Employees employees)
        {
            Employees LEmp = await _Db.Employees.SingleAsync(e=>e.EmpEmail.Equals(employees.EmpEmail));
            if(LEmp.Password.Length > 0)
            {
                bool isValidPassword = BCrypt.Net.BCrypt.Verify(employees.Password,LEmp.Password); 
                if(isValidPassword)
                {
                    var authClaims = new List<Claim> {
                    new Claim(ClaimTypes.Name,employees.EmpEmail)
                    ,new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())
                    };
                    var token = GetJwtToken(authClaims);
                    return Ok(new
                    {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        expiration = token.ValidTo
                    });
                }
            }
            return Unauthorized();
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
        private JwtSecurityToken GetJwtToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuaration["JWT:Secret"]));
            JwtSecurityToken token = new JwtSecurityToken(
                    issuer: configuaration["JWT:ValidIssuer"],
                    audience: configuaration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddMinutes(10),
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );
            return token;
        }
    }
}
