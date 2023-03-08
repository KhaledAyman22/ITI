using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4Demo_43.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult testFun()
        {
            //try
            //{
                string msg = null;
                ViewBag.msgLength = msg.Length; //Error

                return View();
            //}
            //catch
            //{
              //  return View("Error");
            //}
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