using API.DAL;
using API.Entities;

namespace API.BLL
{
    public class CarService : ICarService
    {
        private readonly ICarsRepository _carsRepository;

        public CarService(ICarsRepository carsRepository)
        {
            _carsRepository = carsRepository;
        }

        public bool IsSold(int carId)
        {
            var car = _carsRepository.GetCarById(carId);
            return car?.Owner != null;
        }
    }
}
