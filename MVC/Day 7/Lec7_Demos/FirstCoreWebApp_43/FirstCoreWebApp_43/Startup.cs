using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstCoreWebApp_43
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        //DI Container --> Service Provider
        //Add services to DI Container --> to be enabled for using inside webApp by injection
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc();
            services.AddControllersWithViews();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();  //Middleware Error Handling
            }

            //DefaultFilesOptions options = new DefaultFilesOptions();
            //options.DefaultFileNames.Clear();
            //options.DefaultFileNames.Add("Page1.html");
            //options.DefaultFileNames.Add("Page2.html"); 
            //options.DefaultFileNames.Add("Page3.html");

            //app.UseDefaultFiles(options);  //Default.html -- Index.html -- specific page

            //app.UseStaticFiles();  //Look inside wwwroot folder

            app.UseRouting();  //RoutingTable -- Rows  //Middleware Routing

            app.UseEndpoints(endpoints =>   //Add Entries to Routing Table
            {
                endpoints.MapDefaultControllerRoute();

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
            });
        }
    }
}
