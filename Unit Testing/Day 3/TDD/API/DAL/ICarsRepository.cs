using API.Entities;

namespace API.DAL
{
    public interface ICarsRepository
    {
        Car GetCarById(int carId);
    }
}