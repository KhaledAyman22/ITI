using API.Entities;

namespace API.DAL
{
    public class CarsRepository : ICarsRepository
    {
        private readonly InMemoryContext _inMemoryContext;

        public CarsRepository(InMemoryContext inMemoryContext)
        {
            _inMemoryContext = inMemoryContext;
        }

        public Car GetCarById(int carId)
        {
            return _inMemoryContext.Cars.FirstOrDefault(c => c.Id == carId);
        }
    }
}
