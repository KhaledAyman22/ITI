using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebApp_43.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
