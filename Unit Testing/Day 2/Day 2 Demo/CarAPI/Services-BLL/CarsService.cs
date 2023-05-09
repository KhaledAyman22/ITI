using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using System.Collections.Generic;

namespace CarAPI.Services_BLL
{
    public class CarsService : ICarsService
    {

        private readonly ICarsRepository _carsRepository;

        public CarsService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public List<Car> GetAll()
        {
            var cars = _carsRepository.GetAllCars();
            // Logic on cars
            return cars;
        }

        public Car GetCarById(int id)
        {
            var car = _carsRepository.GetCarById(id);
            /// Logic on the car
            if (car == null) return null;
            return car;
        }

        public bool AddCar(Car car)
        {
            return _carsRepository.AddCar(car);
        }

        public bool Remove(int carId)
        {
            return _carsRepository.Remove(carId);
        }
    }
}