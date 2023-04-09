using CleanHospitalSystem.BL;
using CleanHospitalSystem.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


#region Default 

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

#region Database

var connectionString = builder.Configuration.GetConnectionString("HospitalCon");
builder.Services.AddDbContext<HospitalContext>(options
    => options.UseSqlServer(connectionString));

#endregion

#region Repos

builder.Services.AddScoped<IDoctorsRepo, DoctorsRepo>();
builder.Services.AddScoped<IPatientsRepo, PatientsRepo>();

#endregion

#region Managers

builder.Services.AddScoped<IDoctorsManager, DoctorsManager>();

#endregion

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
