using Microsoft.AspNetCore.Mvc;

namespace SignalRDemo.Controllers
{
    public class ChatRoomController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
