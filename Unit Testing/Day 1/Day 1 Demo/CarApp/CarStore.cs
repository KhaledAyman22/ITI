using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarsApp
{
    public class CarStore
    {
        public List<Car> Cars { get; set; }

        public CarStore()
        {
            Cars = new List<Car>();
        }

        public CarStore(List<Car> cars)
        {
            Cars = cars;
        }

        public List<Car> GetAllStoreCars()
        {
            return Cars;
        }

        public void AddCar(Car car)
        {
            Cars.Add(car);
        }

        public void AddCars(List<Car> cars)
        {
            Cars.AddRange(cars);
        }


    }
}
