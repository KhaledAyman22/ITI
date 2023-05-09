using CarAPI.Entities;
using CarAPI.Repositories_DAL;
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
    public class CarsRepoTests
    {
        private static Mock<InMemoryContext> _inMemoryContext;
        private static CarsRepository _carsRepo;

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            _inMemoryContext = new Mock<InMemoryContext>();
            _inMemoryContext.Setup(x => x.Cars).Returns(new List<Car>() 
            {
                new Car(1, CarType.Audi, 30),
                new Car(2, CarType.Audi, 40),
                new Car(3, CarType.BMW, 50),
            });
            
            _inMemoryContext.Setup(x => x.Owners).Returns(new List<Owner>()
            {
                new Owner(1, "Hesham"),
                new Owner(2, "Sara"),
                new Owner(3, "Waleed"),
            });

            _carsRepo = new CarsRepository(_inMemoryContext.Object);
        }

        [TestMethod]
        public void GetAllCars__Equal()
        {
            // Arrange
            var result = _carsRepo.GetAllCars();
            
            // Act

            //Assert
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddCar_ValidCar_True()
        {
            // Arrange
            var newCar = new Car(4, CarType.Audi, 400);

            // Act
            var result = _carsRepo.AddCar(newCar);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void GetCarById_Id2_True()
        {
            // Arrange
            var id = 2;

            // Act
            var result = _carsRepo.GetCarById(id);

            //Assert
            Assert.AreEqual(result.Id, id);
        }
    }
}
