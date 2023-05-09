using Newtonsoft.Json;
using System.Web.Http;
using CarAPI.DependencyResolver;
using Unity;
using System.ComponentModel;
using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarAPI.Payment;

namespace CarAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters
                   .JsonFormatter.SerializerSettings.Re‌​ferenceLoopHandling
                   = ReferenceLoopHandling.Ignore;

            var container = RegisterServices();

            config.DependencyResolver = new UnityResolver(container);

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }

        private static IUnityContainer RegisterServices()
        {
            var container = new UnityContainer().AddExtension(new Diagnostic());

            container.RegisterType<InMemoryContext>();
            container.RegisterType<ICarsRepository, CarsRepository>();
            container.RegisterType<IOwnersRepository, OwnersRepository>();
            container.RegisterType<ICarsService, CarsService>();
            container.RegisterType<IOwnersService, OwnersService>();
            container.RegisterType<IPaymentService, CashService>("Cash");
            container.RegisterType<IPaymentService, CardService>("Card");

            return container;
        }

    }
}
