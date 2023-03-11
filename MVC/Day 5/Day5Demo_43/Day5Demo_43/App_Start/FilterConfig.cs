using System.Web;
using System.Web.Mvc;

namespace Day5Demo_43
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            //filters.Add(new AuthorizeAttribute() );

            filters.Add(new HandleErrorAttribute() 
            { 
                View = "myErrorPage"
            } );
        }
    }
}
