using Microsoft.AspNetCore.SignalR;
using Task_Day01.Models;

namespace Task_Day01.Hubs
{
    public class ProductsHub : Hub
    {
        private readonly MyDbContext context;

        public ProductsHub(MyDbContext context)
        {
            this.context = context;
        }

        public void Buy(int productId, int quantity)
        {
            var product = context.Products.Find(productId);
            if (product is not null && product.Quantity > 0)
            {
                product.Quantity--;
                context.SaveChanges();
                Clients.All.SendAsync("newTransaction", productId, product.Quantity);
            }
        }
    }
}
