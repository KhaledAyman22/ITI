using Microsoft.EntityFrameworkCore;
using Task_Day01;
using Task_Day01.Hubs;
using Task_Day01.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MyDbContext>(opt => opt.UseSqlServer("Initial Catalog= ProductComments ;Data Source=KHALED;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;"));

builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.MapHub<ProductsHub>("/productsHub");

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
