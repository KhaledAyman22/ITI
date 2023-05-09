using System.Collections.Generic;

namespace CarAPI.Entities
{
    public class InMemoryContext // : DbContext
    {
        public virtual List<Car> Cars { get; set; }
        public virtual List<Owner> Owners { get; set; }
        public InMemoryContext()
        {
            SeedData();
        }

        public void SeedData()
        {
            Car car1 = new Car(1, CarType.Audi, 30);
            Car car2 = new Car(2, CarType.Audi, 40);
            Car car3 = new Car(3, CarType.BMW, 50);

            Cars = new List<Car>()
            {
                car1,car2,car3
            };

            Owner owner1 = new Owner(1, "Hesham");
            Owner owner2 = new Owner(2, "Sara");
            Owner owner3 = new Owner(3, "Waleed");

            car1.Owner = owner1;
            owner1.Car = car1;
            car2.Owner = owner2;
            owner2.Car = car1;

            Owners = new List<Owner>()
            {
                owner1,owner2,owner3
            };
        }

        public Car DeleteCarfromContext(Car car)
        {
            Cars.Remove(car);
            return car;
        }
    }
}