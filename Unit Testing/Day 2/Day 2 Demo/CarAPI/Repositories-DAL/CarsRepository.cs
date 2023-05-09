using CarAPI.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CarAPI.Repositories_DAL
{
    public class CarsRepository : ICarsRepository
    {

        private readonly InMemoryContext _context;

        public CarsRepository(InMemoryContext context)
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