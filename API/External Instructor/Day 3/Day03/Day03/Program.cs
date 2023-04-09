using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion


builder.Services.AddDbContext<APID03Context>(optionts => optionts.UseSqlServer(builder.Configuration.GetConnectionString("DbConn")));

builder.Services
    .AddIdentity<User, IdentityRole>(options =>
    {
        options.Password.RequiredUniqueChars = 3;
        options.Password.RequireUppercase = false;
        options.Password.RequireLowercase = false;
        options.Password.RequireNonAlphanumeric = false;

        options.User.RequireUniqueEmail = true;
    })
    .AddEntityFrameworkStores<APID03Context>();

builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = "MyAuth";
        options.DefaultChallengeScheme = "MyAuth";
    })
    .AddJwtBearer("MyAuth", options =>
    {
        var secretKeyString = builder.Configuration["JWT:Secret"] ?? string.Empty;
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = secretKey,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

builder.Services
    .AddAuthorization(options =>
{
    options.AddPolicy("AllowAny", policy => policy
        .RequireClaim(ClaimTypes.Role, "User", "Admin"));

    options.AddPolicy("AllowUsers", policy => policy
        .RequireClaim(ClaimTypes.Role, "User"));

    options.AddPolicy("AllowAdmins", policy => policy
        .RequireClaim(ClaimTypes.Role, "Admin"));
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseCors();

app.Run();