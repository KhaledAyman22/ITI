using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5Demo_43.Models
{
    public class MyExceptionHandler : HandleErrorAttribute //FilterAttribute, IExceptionFilter
    {
        public override void OnException(ExceptionContext filterContext)
        {
            //if(filterContext.ExceptionHandled || filterContext.HttpContext.IsCustomErrorEnabled == true)
            //{
            //}

            Exception ex = filterContext.Exception;
            filterContext.ExceptionHandled = true;
            filterContext.Result = new ViewResult()
            {
                ViewName = "myErrorPage"
            };

            base.OnException(filterContext);
        }
    }
}
