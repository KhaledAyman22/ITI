using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;

namespace SignalRDemo.Controllers
{
    public class ChatRoomController : Controller
    {
      
        public IActionResult Index()
        {
           // hub.Clients.All.SendAsync()
            return View();
        }
    }
}
