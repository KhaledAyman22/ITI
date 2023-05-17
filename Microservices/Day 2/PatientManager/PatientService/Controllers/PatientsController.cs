using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace PatientService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PatientsController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;

        public PatientsController(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<ActionResult> BookAppointment(BookingRequest request)
        {
            var client = httpClientFactory.CreateClient();

            var response = await client.PostAsJsonAsync("https://localhost:8213/api/appointments", new BookingStatus
            {
                Id = request.Id,
                PatientId = request.PatientId,
                Status = "New"
            });

            return response.IsSuccessStatusCode ? Ok(response) : BadRequest();
        }
    }
}
