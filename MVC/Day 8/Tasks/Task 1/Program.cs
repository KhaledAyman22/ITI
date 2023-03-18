using Microsoft.EntityFrameworkCore;
using Task_1.Controllers;
using Task_1.Models;

namespace Task_1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
           
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ITIContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ITIConn")));

            var app = builder.Build();

            app.UseStaticFiles();
            app.UseRouting();
            app.MapControllerRoute(name: "Default", pattern: "{Controller=Students}/{Action=Index}/{id?}");

            
            if (builder.Environment.IsDevelopment()) 
                app.UseDeveloperExceptionPage();
            else 
                app.UseExceptionHandler();

            app.Run();
        }
    }
}