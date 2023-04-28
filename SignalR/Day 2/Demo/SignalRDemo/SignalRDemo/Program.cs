using SignalRDemo.Hubs;

namespace SignalRDemo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            //register depenancy signal Service "DEault setting"
            builder.Services.AddSignalR();
            builder.Services.AddCors(opt =>
            
                opt.AddDefaultPolicy(policy => 
                    policy.WithOrigins("http://127.0.0.1:62385").AllowAnyMethod()
                    .AllowAnyHeader().AllowCredentials()
                )
            );

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();
            
            app.UseCors();

            app.UseAuthorization();

            app.MapHub<ChatHub>("MyChatHub");
            app.MapHub<EmployeeHub>("EmployeeHub");
            //app.MapHub<class>("route");
            //Mapping Hub
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}