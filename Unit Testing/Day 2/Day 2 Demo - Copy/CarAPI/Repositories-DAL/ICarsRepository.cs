using CarAPI.Entities;
using System.Collections.Generic;

namespace CarAPI.Repositories_DAL
{
    public interface ICarsRepository
    {
        bool AddCar(Car car);
        List<Car> GetAllCars();
        Car GetCarById(int id);
        bool Remove(int carId);
    }
}