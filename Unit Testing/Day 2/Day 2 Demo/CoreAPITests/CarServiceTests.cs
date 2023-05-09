using CoreAPI.BLL;
using Moq;

namespace CoreAPITests
{
    [TestClass]
    public class CarServiceTests
    {
        [TestMethod]
        public void GetCar_ExistingCar_PrintFound()
        {
            int id = 1;
            Mock<ICarRepo> mock = new Mock<ICarRepo>();
            var carService = new CarService(mock.Object);
            mock.Setup(m => m.GetCarById(id)).Returns("Found");

            var expected = "Found";

            var result = carService.GetCar(id);

            StringAssert.Contains(result, expected);
        }
    }
}