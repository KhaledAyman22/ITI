using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task.CustomHandlers
{
    public class CustomExceptionHandler : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;

            var vr = new ViewResult()
            {
                ViewName = "Error",
            };

            vr.ViewBag.msg = ex.Message;
            
            filterContext.Result = vr;

            base.OnException(filterContext);
        }
    }
}