using APis.Identity.Day3.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

#region Cors

var corsPolicy = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicy, p => p.AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
});

#endregion

#region Default

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Database

var connectionString = builder.Configuration.GetConnectionString("Company");
builder.Services.AddDbContext<CompanyContext>(options =>
    options.UseSqlServer(connectionString));

#endregion

#region Identity Managers

builder.Services.AddIdentity<Employee, IdentityRole>(options =>
{
    options.Password.RequiredUniqueChars = 3;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireNonAlphanumeric = false;

    options.User.RequireUniqueEmail = true;
})
    .AddEntityFrameworkStores<CompanyContext>();

#endregion

#region Authentication

builder.Services.AddAuthentication(options =>
{
    //Used Authentication Scheme
    options.DefaultAuthenticateScheme = "CoolAuthentication";

    //Used Challenge Authentication Scheme
    options.DefaultChallengeScheme = "CoolAuthentication";
})
    .AddJwtBearer("CoolAuthentication", options =>
    {
        var secretKeyString = builder.Configuration.GetValue<string>("SecretKey") ?? string.Empty;
        var secretKeyInBytes = Encoding.ASCII.GetBytes(secretKeyString);
        var secretKey = new SymmetricSecurityKey(secretKeyInBytes);

        options.TokenValidationParameters = new TokenValidationParameters
        {
            IssuerSigningKey = secretKey,
            ValidateIssuer = false,
            ValidateAudience = false,
        };
    });

#endregion

#region Authorization

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AllowEngineers", policy => policy
        .RequireClaim(ClaimTypes.Role, "Engineering", "Management")
        .RequireClaim(ClaimTypes.NameIdentifier));

    options.AddPolicy("AllowManagers", policy => policy
        .RequireClaim(ClaimTypes.Role, "Management"));
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(corsPolicy);

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
