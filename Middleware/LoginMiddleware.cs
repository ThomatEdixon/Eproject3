using Microsoft.AspNetCore.Http.Extensions;
using ServiceMarketingSystem.Data;
using ServiceMarketingSystem.Models;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace ServiceMarketingSystem.Middleware
{
    public class LoginMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task InvokeAsync(HttpContext context, DbConnection db)
        {
            // check action login 
            if (context.Request.Path.Equals("/Sercice/Employee/Login"))
            {
                await _next(context);
                return;
            }
            if (context.Request.Path.Equals("/Sercice/Employee//Register"))
            {
                await _next(context);
                return;
            }
            // check authorization
            string? AUTHORIZATION = "Authorization";
            if (!context.Request.Headers.TryGetValue(AUTHORIZATION, out var authorization))
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Authorization was not provided");
                return;
            }
            // decode jwt token
            var handler = new JwtSecurityTokenHandler();
            var token = handler.ReadJwtToken(authorization.ToString().Replace("Bearer ", ""));
            var userEmail = token.Claims.First(c => c.Type == ClaimTypes.Name).Value;
            Employees? userLogin = db.Employees.FirstOrDefault(u => u.EmpEmail.Equals(userEmail));
            if (userLogin is null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("User have not existence");
                return;
            }

            // get list slug
            List<Slug> slugs = db.Slug.Where(s => s.RoleId == userLogin.RoleId).ToList();
            if (!slugs.Any())
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("Slugs was not provided");
                return;
            }
            //check url 
            var url = context.Request.GetDisplayUrl();
            Debug.WriteLine(url);
            var s = slugs.FirstOrDefault(s => s.URI.Equals(url));
            if (s is null)
            {
                context.Response.StatusCode = 401;
                await context.Response.WriteAsync("User can not run action");
                return;
            }
            await _next(context);
        }
    }
}
