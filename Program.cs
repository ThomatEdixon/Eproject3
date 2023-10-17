using Microsoft.EntityFrameworkCore;
using ServiceMarketingSystem.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ServiceMarketingSystem.Services;
using ServiceMarketingSystem.Middleware;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager _Configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DbConnection>(options => options.UseSqlServer(
        builder.Configuration.GetConnectionString("SqlConnectionString")
    ));
builder.Services.AddAuthentication(opt =>
{
    opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt => {
    opt.SaveToken = true;
    opt.RequireHttpsMetadata = false;
    opt.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = _Configuration["JWT:ValidAudience"],
        ValidIssuer = _Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_Configuration["JWT:Secret"]))
    };
});

builder.Services.AddSingleton<IJWTManagerService, JWTManagerService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<DbConnection>();

builder.Services.AddCors(options => options.AddPolicy(name: "MyRequestMVCAPI",
        policy =>
        {
            policy.WithOrigins("https://localhost:3000")
            .AllowAnyHeader()
            .AllowAnyMethod();
        }
    ));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseCors("MyRequestMVCAPI");

app.UseMiddleware<LoginMiddleware>();

app.MapControllers();

app.Run();
