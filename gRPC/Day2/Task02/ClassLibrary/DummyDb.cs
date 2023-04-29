namespace ClassLibrary
{
    public class DummyDb
    {
        public static List<Product> Products { get; } = new()
        {
            new() {Id = 1, Name = "Product A", Price = 9.99, Stock = 100},
            new() {Id = 2, Name = "Product B", Price = 15.99, Stock = 50},
            new() {Id = 3, Name = "Product C", Price = 7.99, Stock = 200},
            new() {Id = 4, Name = "Product D", Price = 12.49, Stock = 75},
            new() {Id = 5, Name = "Product E", Price = 24.99, Stock = 25},
            new() {Id = 6, Name = "Product F", Price = 6.99, Stock = 150},
            new() {Id = 7, Name = "Product G", Price = 19.99, Stock = 80},
            new() {Id = 8, Name = "Product H", Price = 8.49, Stock = 120},
            new() {Id = 9, Name = "Product I", Price = 5.99, Stock = 250},
            new() {Id = 10, Name = "Product J", Price = 16.99, Stock = 60},
        };

        public static List<User> Users { get; } = new() {
            new() { Id = 1, Name = "Alice", Balance = 100.0 },
            new() { Id = 2, Name = "Bob", Balance = 50.0 },
            new() { Id = 3, Name = "Charlie", Balance = 75.5 },
            new() { Id = 4, Name = "David", Balance = 200.0 },
            new() { Id = 5, Name = "Emily", Balance = 150.0 },
            new() { Id = 6, Name = "Frank", Balance = 75.0 }
        };
    }
}
