using ClassLibrary;
using Grpc.Core;
using static InventoryService.InventoryChecker;

namespace InventoryService.Services
{
    public class CheckInventoryService : InventoryCheckerBase
    {
        public override Task<CheckInventoryReply> CheckInventory(CheckInventoryRequest request, ServerCallContext context)
        {
            var product = DummyDb.Products.FirstOrDefault(p => p.Id == request.Id);

            if (product == null || product.Stock < request.Quantity)
                return Task.FromResult(new CheckInventoryReply() { Approved = false, Due = 0 });

            product.Stock -= request.Quantity;

            return Task.FromResult(new CheckInventoryReply() { Approved = true, Due = request.Quantity * product.Price });
        }
    }
}
