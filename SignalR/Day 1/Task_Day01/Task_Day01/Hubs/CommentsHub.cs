using Microsoft.AspNetCore.SignalR;
using Task_Day01.Models;

namespace Task_Day01.Hubs
{
    public class CommentsHub : Hub
    {
        private readonly MyDbContext context;

        public CommentsHub(MyDbContext context)
        {
            this.context = context;
        }

        public void AddComment(string username, string comment, int productId)
        {
            var cmnt = new Comment()
            {
                ProductId = productId,
                Username = username,
                Text = comment,
            };

            context.Comments.Add(cmnt);
            context.SaveChanges();

            Clients.All.SendAsync("newComment", username, comment, productId);
        }
    }
}
