namespace CoreAPI.BLL
{
    public interface ICarService
    {
        public string GetCar(int id);
    }
    public interface ICarRepo
    {
        public string GetCarById(int id);
    }

    public class CarRepo : ICarRepo
    {
        public string GetCarById(int id)
        {
            return $"Car {id} is found";
        }
    }
    public class CarService : ICarService
    {
        private readonly ICarRepo _carRepo;

        public CarService(ICarRepo carRepo)
        {
            _carRepo = carRepo;
        }
        public string GetCar(int id)
        {
            return _carRepo.GetCarById(id);
        }
    }
}
