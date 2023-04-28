namespace Task_Day01.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Quantity { get; set; }
        public ICollection<Comment> Comments { get; set; } = new List<Comment>();
    }
}
