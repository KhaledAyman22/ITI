using CarAPI.Entities;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPITests
{
    [TestClass]
    public class CarsServiceTests
    {
        private static Mock<ICarsRepository> _carsRepository;
        private static CarsService _carsService;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _carsRepository = new Mock<ICarsRepository>();
            _carsService = new CarsService(_carsRepository.Object);
        }

        [TestMethod]
        public void GetAll__ValidList()
        {
            // Arrange
            var cars = new List<Car>
            {
                new Car(1, CarType.Audi, 30),
                new Car(2, CarType.Audi, 40),
                new Car(3, CarType.BMW, 50),
            };

            _carsRepository.Setup(r => r.GetAllCars()).Returns(cars);

            // Act
            var result = _carsService.GetAll();

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void GetCarById_Id2_ValidCar()
        {
            // Arrange
            var cars = new List<Car>
            {
                new Car(1, CarType.Audi, 30),
                new Car(2, CarType.Audi, 40),
                new Car(3, CarType.BMW, 50),
            };

            var id = 2;
            var expected = cars[1];

            _carsRepository.Setup(r => r.GetCarById(id)).Returns(expected);

            // Act
            var result = _carsService.GetCarById(id);

            //Assert
            Assert.AreEqual(result, expected);
        }

        [TestMethod]
        public void Remove_Id3_False()
        {
            // Arrange
            var cars = new List<Car>
            {
                new Car(1, CarType.Audi, 30),
                new Car(2, CarType.Audi, 40),
                new Car(3, CarType.BMW, 50),
            };

            var id = 3;
            var expected = false;

            _carsRepository.Setup(r => r.Remove(id)).Returns(expected);

            // Act
            var result = _carsService.Remove(id);

            //Assert
            Assert.IsFalse(result);
        }
    }
}
