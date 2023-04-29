using Grpc.Net.Client;
using InventoryService;
using Microsoft.AspNetCore.Mvc;
using PaymentService;

namespace OrderingService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public UsersController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Buy(int productId, int quantity, int userId)
        {
            using var channel1 = GrpcChannel.ForAddress(_configuration["InventoryService"]!);

            var client1 = new InventoryChecker.InventoryCheckerClient(channel1);

            var response1 = await client1.CheckInventoryAsync(new CheckInventoryRequest { Id = productId, Quantity = quantity });

            if (!response1.Approved) return BadRequest("No enough inventory");

            using var channel2 = GrpcChannel.ForAddress(_configuration["PaymentService"]!);

            var client2 = new PaymentChecker.PaymentCheckerClient(channel2);

            var response2 = await client2.CheckPaymentAsync(new CheckPaymentRequest { Id = userId, Due = response1.Due });

            if (!response2.Approved)
            {
                using var channel3 = GrpcChannel.ForAddress(_configuration["InventoryService"]!);

                var client3 = new InventoryRestocker.InventoryRestockerClient(channel3);

                var response3 = await client3.RestockInventoryAsync(new RestockInventoryRequest { Id = productId, Quantity = quantity });

                return BadRequest("No enough balance");
            }

            return Ok();
        }
    }
}
