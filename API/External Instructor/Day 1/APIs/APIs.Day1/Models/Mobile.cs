namespace APIs.Day1.Models;


public class Mobile
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Model { get; set; } = string.Empty;
    public double Price { get; set; }

    public Mobile(int id,
        string name,
        string model,
        double price)
    {
        Id = id;
        Name = name;
        Model = model;
        Price = price;
    }

    public static List<Mobile> Mobiles = new ()
    {
        new (1, "Samsung", "Galaxy S21", 799.99),
        new (2, "Apple", "iPhone 13", 999.99),
        new (3, "OnePlus", "9 Pro", 699.99),
        new (4, "Huawei", "P50 Pro", 899.99),
        new (5, "Nokia", "8.", 499.99)
    };
}
