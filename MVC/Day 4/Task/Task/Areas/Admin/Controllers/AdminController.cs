using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task.Areas.Admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin/Admin
        [HandleError(View = "Error1")]
        public ActionResult Index()
        {
            string x = null;
            Console.WriteLine(x.Length);
            return View();
        }
    }
}