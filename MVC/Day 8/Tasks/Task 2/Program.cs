using Microsoft.EntityFrameworkCore;
using Task_2.Models;

namespace Task_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<StudentCourseContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("StudentCourseConn")));


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