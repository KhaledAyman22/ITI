using Grpc.Core;
using Grpc.Net.Client;
using InventoryService;
using OrderingService;
using PaymentService;
using static OrderingService.Order;

namespace OrderService.Services
{
    public class OrderService : OrderBase
    {
        public override async Task<OrderReply> PlaceOrder(OrderRequest request, ServerCallContext context)
        {
            using var channel1 = GrpcChannel.ForAddress("https://localhost:7233");

            var client1 = new InventoryChecker.InventoryCheckerClient(channel1);

            var response1 = await client1.CheckInventoryAsync(new CheckInventoryRequest { Id = request.ProductId, Quantity = request.Quantity });

            if (!response1.Approved) return new() { Message = "No enough inventory" };

            using var channel2 = GrpcChannel.ForAddress("https://localhost:7027");

            var client2 = new PaymentChecker.PaymentCheckerClient(channel2);

            var response2 = await client2.CheckPaymentAsync(new CheckPaymentRequest { Id = request.UserId, Due = response1.Due });

            if (!response2.Approved)
            {
                using var channel3 = GrpcChannel.ForAddress("https://localhost:7233");

                var client3 = new InventoryRestocker.InventoryRestockerClient(channel3);

                var response3 = await client3.RestockInventoryAsync(new RestockInventoryRequest { Id = request.ProductId, Quantity = request.Quantity });

                return new() { Message = "No enough balance" };
            }

            return new() { Message = "Order placed successfully" };
        }
    }
}
