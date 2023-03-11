using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5Demo_43.Models
{
    public class MyLogFilter : ActionFilterAttribute //FilterAttribute, IActionFilter
    {
        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            Debug.WriteLine("OnActionExecuted Log: " +
                "Action: " + filterContext.RouteData.Values["action"] +
                ", Controller: " + filterContext.RouteData.Values["controller"]);
        }

        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            Debug.WriteLine("OnResultExecuted Log: " +
          "HttpMethod: " + filterContext.HttpContext.Request.HttpMethod +
          " Action: " + filterContext.RouteData.Values["action"] +
          ", Controller: " + filterContext.Controller);
        }
    }
}