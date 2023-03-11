using Day5Demo_43.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Day5Demo_43.Controllers
{
    //[Authorize]
    //[Route("Hm")]
    [RoutePrefix("Hm")]
    public class HomeController : Controller
    {
        [OutputCache(Duration = 30, VaryByParam = "x; y")]
        public string getCurTime(int x, int y, int z)
        {
            return DateTime.Now.ToString();
        }

        [Route("~/Main/All")]
        public ActionResult Index()
        {
            return View();
        }

        [MyLogFilter]
        [Route("")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        //[NonAction]
        [ActionName("MyContact")]
        [Route("ContactUs")]
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View("Contact");
        }

        //[MyExceptionHandler(View = "myErrorPage")]
        [MyExceptionHandler]
        public ActionResult Index2()
        {
            int a = 5;
            int b = 0;
            int c = 0;
            c = a / b; //it would cause exception.   

            return View();
        }
    }
}