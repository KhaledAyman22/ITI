using CarAPI.Entities;
using CarAPI.Models;
using CarAPI.Payment;
using CarAPI.Repositories_DAL;
using CarAPI.Services_BLL;
using CarAPITests.Fake;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace CarAPITests
{
    [TestClass]
    public class OwnerServiceTests
    {
        private static Mock<IOwnersRepository> _ownersRepositoryMock;
        private static Mock<ICarsRepository> _carsRepositoryMock;
        private static Mock<IPaymentService> _paymentServiceMock;
        private static OwnersService _ownersService;

        [ClassInitialize]
        public static void CreateOwnerService(TestContext context) 
        {
            _ownersRepositoryMock = new Mock<IOwnersRepository>();
            _carsRepositoryMock = new Mock<ICarsRepository>();
            _paymentServiceMock = new Mock<IPaymentService>();
            _ownersService = new OwnersService(_ownersRepositoryMock.Object, _carsRepositoryMock.Object, _paymentServiceMock.Object);
        }


        #region Tightly coupled
        [TestMethod]
        public void BuyCar_NotSoldCarId3Owner3_PrintSuccessful_TightlyCoupled()
        {
            // Arrange
            var _ownersService = new OwnersService(
                new OwnersRepository(new CarAPI.Entities.InMemoryContext()),
                new CarsRepository(new CarAPI.Entities.InMemoryContext()),
                new CashService()
                );
            var input = new BuyCarInput()
            {
                Amount = 200,
                CarId = 3,
                OwnerId = 3
            };
            var expected = "Successfull";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expected);
        }
        // Depend on direct implementations of dependencies
        // State change in DB
        #endregion

        #region Fake Data
        [TestMethod]
        public void BuyCar_NotSoldCarId3Owner3_PrintSuccessful_Fake()
        {
            // Arrange
            var _ownersService = new OwnersService(
                new FakeOwnersRepository(new FakeContext()),
                new FakeCarsRepository(new FakeContext()),
                new FakePaymentService()
                );
            var input = new BuyCarInput()
            {
                Amount = 200,
                CarId = 3,
                OwnerId = 3
            };
            var expected = "Successfull";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expected);
        }
        #endregion


        #region Mocking
        [TestMethod]
        public void BuyCar_NotSoldCarId1Owner1_PrintSuccessful_Mocking()
        {
            // Arrange           
            var input = new BuyCarInput()
            {
                Amount = 200,
                CarId = 1,
                OwnerId = 1
            };
            var car = new Car(input.CarId, CarType.Audi, 0);
            var owner = new Owner(input.OwnerId, "Moustafa");
            _ownersRepositoryMock.Setup(m => m.GetOwnerById(input.OwnerId)).Returns(owner);
            _carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns(car);
            _paymentServiceMock.Setup(m => m.Pay(input.Amount)).Returns("");
            var expected = "Successfull";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expected);
        }

        [TestMethod]
        public void BuyCar_SoldCarId1Owner1_Sold_Mocking()
        {
            // Arrange
            var input = new BuyCarInput()
            {
                Amount = 200,
                CarId = 1,
                OwnerId = 1
            };
            var car = new Car(input.CarId, CarType.Audi, 0);
            car.Owner = new Owner();
            _carsRepositoryMock.Setup(m => m.GetCarById(input.CarId)).Returns(car);
            var expected = "sold";

            // Act
            var result = _ownersService.BuyCar(input);

            // Assert
            StringAssert.Contains(result, expected);
        }
        #endregion

        #region Parameterized Unit tests
        public class Calc
        {
            public int Add(int val1, int val2)
            {
                return val1 + val2;
            }
        }

        [DataTestMethod]
        [DataRow(1, 2, 3)]
        [DataRow(-1, -2, -3)]
        [DataRow(1, -2, -1)]
        public void Add_1And2_3(int val1, int val2, int expected)
        {
            var calc = new Calc();

            var result = calc.Add(val1, val2);

            Assert.AreEqual(expected, result);
        } 
        #endregion
    }
}
