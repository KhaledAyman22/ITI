using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Task.Areas.Finance.Controllers
{
    [HandleError(View = "Error2", ExceptionType = typeof(DivideByZeroException))]
    public class FinanceController : Controller
    {
        // GET: Finance/Finance
        public ActionResult Index()
        {
            int x = 0;
            int ÿ = 1 / x;
            return View();
        }
    }
}