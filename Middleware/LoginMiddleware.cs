using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ServiceMarketingSystem.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly TokenValidationParameters _validationParameters;
        private readonly IConfiguration configuration;

        public LoginMiddleware(
            RequestDelegate __next,
            IOptions<JwtBearerOptions> jwtOptions,
            IConfiguration configuration
        )
        {
            _next = __next ?? throw new ArgumentNullException("Not Found Next Delegate");
            _validationParameters = jwtOptions.Value.TokenValidationParameters;
            this.configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context, IServiceProvider serviceProvider)
        {
            if (context == null)
            {
                throw new ArgumentNullException("Context not found");
            }
            if (context.Request.Path.Equals("/Service/Employee/Login", StringComparison.OrdinalIgnoreCase))
            {
                await _next(context);
                return;
            }
            if (
                context.Request.Path.Equals("/Service/Employee/Logout", StringComparison.OrdinalIgnoreCase)
            )
            {
                await _next(context);
                return;
            }
            if (
                context.Request.Path.Equals("/Service/Employee/Register", StringComparison.OrdinalIgnoreCase
                )
            )
            {
                await _next(context);
                return;
            }
            if (
                context.Request.Path.Equals(
                    "/Service/Employee/Refresh",
                    StringComparison.OrdinalIgnoreCase
                )
            )
            {
                await _next(context);
                return;
            }
            string? AUTHORIZATION = "Authorization";
            if (!context.Request.Headers.TryGetValue(AUTHORIZATION, out var authorization))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization was not provided");
                return;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.ReadJwtToken(authorization.ToString().Replace("Bearer ", ""));
            Debug.WriteLine(token);
            var employeesEmail = token.Claims.First(c => c.Type == JwtRegisteredClaimNames.Name).Value;
            Debug.WriteLine(employeesEmail);
            string requestUri = context.Request.GetEncodedUrl();

            string slug = requestUri;
            Slug slugRole = null;

            if (token is null)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Missing JWT token.");
                return;
            }
            var key = Encoding.UTF8.GetBytes(configuration["JWT:Secret"]);

            var _Db = serviceProvider.GetRequiredService<DbConnection>();

            try
            {
                // Check slug
                Employees employees = _Db.Employees.SingleOrDefault(e => e.EmpEmail.Equals(employeesEmail));
                if (employeesEmail is null)
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("User have not existence");
                    return;
                }
                List<Slug> slugs = _Db.Slug.Where(s => s.RoleId == employees.RoleId).ToList();
                if (!slugs.Any())
                {
                    context.Response.StatusCode = 401;
                    await context.Response.WriteAsync("Slugs was not provided");
                    return;
                }
            }
            catch (SecurityTokenException)
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsJsonAsync(new { Message = "Invalid JWT token." });
            }

            await _next(context);
        }
    }
}
