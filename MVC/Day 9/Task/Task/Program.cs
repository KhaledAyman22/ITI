using Microsoft.EntityFrameworkCore;
using FinalTask.Contracts;
using FinalTask.Models;
using FinalTask.Repositories;
using FinalTask.Areas.Identity.Data;
using FinalTask.Data;
using Microsoft.AspNetCore.Identity;

namespace FinalTask
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<TraineesDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("TraineesConn")));
            builder.Services.AddDbContext<UserAccountsContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("UserAccountsContextConn")));

            builder.Services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = false).AddEntityFrameworkStores<UserAccountsContext>();

            builder.Services.AddScoped<ITrackRepo, TrackRepo>();
            builder.Services.AddScoped<ICourseRepo, CourseRepo>();
            builder.Services.AddScoped<ITraineeRepo, TraineeRepo>();
            #endregion
      
            
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

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapRazorPages();

            app.Run();
        }
    }
}