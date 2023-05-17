using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Schedular.Services;

namespace Schedular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchedularController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly INotificationService notificationService;

        public SchedularController(IHttpClientFactory httpClientFactory, INotificationService notificationService)
        {
            this.httpClientFactory = httpClientFactory;
            this.notificationService = notificationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ShipmentRequest request)
        {
            // Invoke Delivery Service to update the status
            var client = httpClientFactory.CreateClient();

            var response = await client.PutAsJsonAsync("https://localhost:8299/api/deliveryStatus", new DeliveryStatus
            {
                Id = request.Id,
                Status = "New"
            });

            if (response.IsSuccessStatusCode)
            {
                // Send Notification
                await notificationService.Send(new NotificationMessage
                {
                    To = request.UserName,
                    Message = "Shipment placed"
                });

                return Ok();
            }

            return BadRequest(response);
        }
    }
}
