using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp_43
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
