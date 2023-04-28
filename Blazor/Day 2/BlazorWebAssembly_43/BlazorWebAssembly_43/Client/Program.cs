using BlazorWebAssembly_43;
using BlazorWebAssembly_43.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

namespace BlazorWebAssembly_43
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);

            builder.RootComponents.Add<App>("#app");
            
            builder.RootComponents.Add<HeadOutlet>("head::after");


            builder.Services.AddHttpClient<IEmployeeDataService, EmployeeDataService>(
                client => client.BaseAddress = new Uri("https://localhost:7087")
                );

            builder.Services.AddHttpClient<ICountryDataService, CountryDataService>(
                c => c.BaseAddress = new Uri("https://localhost:7087")
                );

            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}