using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Concurrent;

namespace DeliveryService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryStatusController : ControllerBase
    {
        private static ConcurrentDictionary<Guid, string> deliveryStatuses = new ConcurrentDictionary<Guid, string>();

        [HttpGet]
        [Route("{id}")]
        public IActionResult Get(Guid id)
        {
            return deliveryStatuses.TryGetValue(id, out var status) ?
                 Ok(status) : NotFound($"No matched record for {id}");
        }

        [HttpPut]
        public IActionResult UpdateStatus(DeliveryStatus status)
        {
            deliveryStatuses.AddOrUpdate(status.Id, status.Status, (id, sts) => status.Status);

            return Ok();
        }
    }
}
