using Day8_Core_43.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Day8_Core_43
{
    public class Startup
    {
        //request service of type IConfiguration to be used here, create & inject this service 

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment WebHost { get; }

        public Startup(IConfiguration configuration, IWebHostEnvironment webHost)
        {
            Configuration = configuration;
            WebHost = webHost;
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();  //Enable MVC Service "Contained"  

            services.AddDbContext<ProductDbContext>(op =>
                //op.UseSqlServer("Data Source=.;Initial Catalog=ProductsDb_43;Integrated Security=True")
                //op.UseSqlServer(Configuration["ConnectionStrings:myConn"])
                op.UseSqlServer(Configuration.GetConnectionString("myConn"))
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //Styles Path from Local
                //connectionstring to test DB
            }
            else if (env.IsProduction()) 
            {
                app.UseExceptionHandler();
                //Styles Path from CDN
                //connectionstring to Final DB
            }
            else if(env.IsEnvironment("StagingAfterFirstChange"))
            { }

            app.UseStaticFiles(); //wwwroot --> static Files

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute
                (
                    name: "myOwnRoute",
                    pattern:"{Controller=Product}/{Action=Index}/{id?}"
                );

               // endpoints.MapDefaultControllerRoute();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!" +
                //        "\n" + Configuration["myKey"]);
                //});
            });
        }
    }
}
