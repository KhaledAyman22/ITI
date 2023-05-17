using AppointmentService.Services;
using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace AppointmentService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppointmentsController : ControllerBase
    {
        private static ConcurrentDictionary<int, string> bookingsStatuses = new ConcurrentDictionary<int, string>();

        private readonly INotificationService notificationService;

        public AppointmentsController(INotificationService notificationService)
        {
            this.notificationService = notificationService;
        }


        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(int id)
        {
            return bookingsStatuses.TryGetValue(id, out var status) ?
                 Ok(status) : NotFound($"No matched record for {id}");
        }

        [HttpPost]
        public async Task Book(BookingStatus status)
        {
            bookingsStatuses.AddOrUpdate(status.Id, status.Status, (id, sts) => status.Status);

            //await Task.Delay(10000);

            bookingsStatuses.AddOrUpdate(status.Id, "Confirmed", (id, sts) => "Confirmed");

            await notificationService.Send(new NotificationMessage
            {
                To = status.PatientId,
                Message = "Booking Confirmed"
            });
        }
    }
}
