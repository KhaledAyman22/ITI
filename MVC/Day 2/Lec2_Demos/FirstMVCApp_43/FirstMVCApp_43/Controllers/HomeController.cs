using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FirstMVCApp_43.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult testFun()
        {
            //return "Hello MVC World!";

            //ViewResult result = new ViewResult();
            //result.ViewName = "testFun";

            //return result;

            ViewData["msg"] = "Hello MVC World...";

            ViewBag.str = "string from viewbag";

            return View();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}