using System.Web;
using System.Web.Mvc;

namespace Identity_ExternalLogins_43
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
