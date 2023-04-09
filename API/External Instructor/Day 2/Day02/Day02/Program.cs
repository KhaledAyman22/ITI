using BL.Managers.Departments;
using BL.Managers.Tickets;
using DAL.Context;
using DAL.Repos.Departments;
using DAL.Repos.Developers;
using DAL.Repos.Tickets;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

#region Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

builder.Services.AddControllers();

builder.Services.AddDbContext<APIDay02Context>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("APID02Conn")));


builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<IDeveloperRepo, DeveloperRepo>();
builder.Services.AddScoped<IDepartmentManager, DepartmentManager>();
builder.Services.AddScoped<ITicketManager, TicketManager>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
