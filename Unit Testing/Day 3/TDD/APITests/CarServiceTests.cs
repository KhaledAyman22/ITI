using API.Entities;
using API.BLL;
using Moq;
using API.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using API.Controllers;
using Castle.Core.Logging;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;

namespace APITests
{
    [TestClass]
    public class CarServiceTests
    {
        [TestMethod]
        public void IsSold_CarAlreadySold_True()
        {
            // Arrange
            int carId = 1;
            var car = new Car(carId);
            var owner = new Owner();
            car.Owner = owner;
            Mock<ICarsRepository> mockContext = new Mock<ICarsRepository>();
            var carService = new CarService(mockContext.Object);
            mockContext.Setup(m => m.GetCarById(carId)).Returns(car);

            // Act
            var result = carService.IsSold(carId);


            // Assert
            Assert.IsTrue(result);
        }

        /*[TestMethod]
        public void MyTestMethod()
        {
            Mock<ICarService> mock = new Mock<ICarService>();   
            var controller = new CarsController(mock.Object);
            var expected = true;
            mock.Setup(m => m.IsSold(1)).Returns(expected);

            var result = controller.Get(1);

            Assert.AreEqual(expected, result);
        }*/
    }
}