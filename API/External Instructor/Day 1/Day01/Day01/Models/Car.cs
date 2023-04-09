using Day01.Validators;

namespace Day01.Models
{
    public class Car
    {
        public int Id { get; set; }
        
        public string Model { get; set; }
        
        public string Make { get; set; }
        
        [ProductionDate(ErrorMessage = "Production date can't be in the future.")]
        public DateTime ProductionDate { get; set; }
        
        public string Type { get; set; }
        
        public static List<Car> Cars = new()
        {
            new() { Id = 1,Model = "Camry", Make = "Toyota", ProductionDate = new DateTime(2021, 10, 1), Type = "Gas" },
            new() { Id = 2,Model = "Accord", Make = "Honda", ProductionDate = new DateTime(2022, 2, 15), Type = "Gas" },
            new() { Id = 3,Model = "Altima", Make = "Nissan", ProductionDate = new DateTime(2021, 8, 23), Type = "Gas" },
            new() { Id = 4,Model = "Mustang", Make = "Ford", ProductionDate = new DateTime(2022, 5, 7), Type = "Gas" },
            new() { Id = 5,Model = "Corvette", Make = "Chevrolet", ProductionDate = new DateTime(2021, 12, 1), Type = "Gas" },
            new() { Id = 6,Model = "Charger", Make = "Dodge", ProductionDate = new DateTime(2022, 1, 30), Type = "Gas" },
            new() { Id = 7,Model = "3 Series", Make = "BMW", ProductionDate = new DateTime(2021, 6, 15), Type = "Gas" },
            new() { Id = 8,Model = "C-Class", Make = "Mercedes-Benz", ProductionDate = new DateTime(2022, 3, 20), Type = "Gas" },
            new() { Id = 9,Model = "A4", Make = "Audi", ProductionDate = new DateTime(2021, 9, 5), Type = "Gas" },
            new() { Id = 10,Model = "ES", Make = "Lexus", ProductionDate = new DateTime(2022, 4, 10), Type = "Gas" }
        };

        public static int Requests = 0;
    }


}
