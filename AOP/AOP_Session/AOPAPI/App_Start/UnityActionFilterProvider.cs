using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Unity;

namespace AOPAPI.App_Start
{
    public class UnityActionFilterProvider : ActionDescriptorFilterProvider, IFilterProvider
    {
        private readonly IUnityContainer container;
        public UnityActionFilterProvider(IUnityContainer container)
        {
            this.container = container;
        }
        public new IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(configuration, actionDescriptor);
            foreach (var filter in filters)
            {
                container.BuildUp(filter.Instance.GetType(), filter.Instance);
            }
            return filters;
        }
        public static void RegisterFilterProvider(HttpConfiguration configs)
        {
            var providers = configs.Services.GetFilterProviders().ToList();
            configs.Services.Add(typeof(IFilterProvider), new UnityActionFilterProvider(UnityConfig.Container));
            var defaultprovider = providers.First(p => p is ActionDescriptorFilterProvider);
            configs.Services.Remove(typeof(IFilterProvider), defaultprovider);
        }
    }
}