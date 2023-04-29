using ClassLibrary;
using Grpc.Core;
using static InventoryService.InventoryRestocker;

namespace InventoryService.Services
{
    public class RestockInventoryService : InventoryRestockerBase
    {
        public override Task<RestockInventoryReply> RestockInventory(RestockInventoryRequest request, ServerCallContext context)
        {
            var product = DummyDb.Products.FirstOrDefault(p => p.Id == request.Id);

            if (product == null)
                return Task.FromResult(new RestockInventoryReply() { Approved = false });

            product.Stock += request.Quantity;

            return Task.FromResult(new RestockInventoryReply() { Approved = true });
        }
    }
}
