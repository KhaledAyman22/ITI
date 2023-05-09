using CarAPI.Entities;
using System.Collections.Generic;

namespace CarAPI.Services_BLL
{
    public interface ICarsService
    {
        bool AddCar(Car car);
        List<Car> GetAll();
        Car GetCarById(int id);
        bool Remove(int carId);
    }
}