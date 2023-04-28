using System.ComponentModel.DataAnnotations.Schema;

namespace Task_Day01.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; } = string.Empty;
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        public string Username { get; set; } = string.Empty;
    }
}
