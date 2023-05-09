using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPITests.Fake
{
    public class FakeCarsRepository : ICarsRepository
    {
        private readonly FakeContext _context;

        public FakeCarsRepository(FakeContext context)
        {
            _context = context;
        }

        public List<Car> GetAllCars()
        {
            // Get cars from dependency
            // Logic
            return _context.Cars;
        }

        public Car GetCarById(int id)
        {
            return _context.Cars.FirstOrDefault(c => c.Id == id);
        }

        public bool AddCar(Car car)
        {
            _context.Cars.Add(car);
            return true;
        }

        public bool Remove(int carId)
        {
            var car = _context.Cars.Find(c => c.Id == carId);
            return _context.Cars.Remove(car);
        }
    }
}
