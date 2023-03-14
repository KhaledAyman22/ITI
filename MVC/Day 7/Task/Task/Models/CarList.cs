using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models;

namespace Task_1.Models
{
    public static class CarList
    {
        public static List<Car> Cars = new List<Car>() {
            new Car(){ Num = 1, Color = "Red", Manufacture = "Toyota", Model = "Camry" },
            new Car(){ Num = 2, Color = "Blue", Manufacture = "Honda", Model = "Civic" },
            new Car(){ Num = 3, Color = "Black", Manufacture = "Ford", Model = "F-150" },
            new Car { Num = 4, Color = "White", Manufacture = "Nissan", Model = "Altima" },
            new Car { Num = 5, Color = "Silver", Manufacture = "Chevrolet", Model = "Malibu" },
            new Car { Num = 6, Color = "Green", Manufacture = "Subaru", Model = "Outback" },
            new Car { Num = 7, Color = "Yellow", Manufacture = "Volkswagen", Model = "Beetle" },
            new Car { Num = 8, Color = "Gray", Manufacture = "BMW", Model = "X5" },
        };
    }
}