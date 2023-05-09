using CarAPI.Entities;
using CarAPI.Services_BLL;
using System.Collections.Generic;
using System.Web.Http;

namespace CarAPI.Controllers
{
    public class CarsController : ApiController
    {
        public readonly ICarsService _carService;

        public CarsController(ICarsService carsService)
        {
            _carService = carsService;
        }

        [HttpGet]
        public List<Car> Get()
        {
            return _carService.GetAll();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Car Get(int id)
        {
            return _carService.GetCarById(id);
        }

        [HttpPost]
        public bool Post([FromBody] Car car)
        {
            return _carService.AddCar(car);
        }

        [HttpDelete]
        public bool Delete(int carId)
        {
            return _carService.Remove(carId);
        }

    }
}
