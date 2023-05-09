using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CarAppTests
{
    [TestClass]
    public class CarTests
    {

        #region Initialize
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext context)
        {
            context.WriteLine("Class init");
        }

        [ClassCleanup]
        public static void ClassCleanup() { }

        [TestInitialize]
        public void TestInit()
        {
            TestContext.WriteLine("Test init");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            TestContext.WriteLine("Test clean up");
        }

        public CarTests()
        {
            Console.WriteLine("CTOR");
        }
        #endregion

        #region Assert

        [Owner("Mohamed")]
        [TestCategory("Equality")]
        [Priority(1)]
        [TestMethod]
        public void TimeToCoverProvidedDistance_Distance100Velocity25_Time4()
        {
            // Arrange
            Car car = new Car
            {
                Velocity = 25
            };
            double distance = 100;
            double expectedResult = 4;

            // Act
            double actualResult = car.TimeToCoverProvidedDistance(distance);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestCategory("Equality")]
        [Owner("Sara")]
        [TestMethod]

        public void TwoCars_DifferentInstancesSameState_EqualCars()
        {
            // Arrange
            Car car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            // Act

            // Assert
            Assert.AreEqual(car1, car2);
        }

        [TestCategory("Equivalence")]
        [TestMethod]
        public void TwoCars_DifferentInstancesSameState_NotSame()
        {
            // Arrange
            Car car1 = new Car(CarType.Audi, 100, DrivingMode.Forward);
            Car car2 = new Car(CarType.Audi, 100, DrivingMode.Forward);

            // Act

            // Assert
            Assert.AreNotSame(car1, car2);
        }

        [Owner("Mohamed")]
        [TestMethod]
        public void GetMyCar_ExistingInstance_NotNull()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualCar = car.GetMyCar();

            // Assert
            Assert.IsNotNull(actualCar);
        }

        [Priority(1)]
        [TestMethod]
        public void GetMyCar_ExistingInstance_IsCarType()
        {
            // Arrange
            var car = new Car();

            // Act
            var actualCar = car.GetMyCar();

            // Assert
            Assert.IsInstanceOfType(actualCar, typeof(Car));
        }

        [Ignore]
        [Priority(2)]
        [TestMethod]
        public void IsStopped_Velocity0_True()
        {
            var car = new Car()
            {
                Velocity = 0
            };

            var result = car.IsStopped();

            Assert.IsTrue(result);
        }
        #endregion


        #region String Assert
        [TestMethod]
        public void GetDirection_Forward_PrintForward()
        {
            var car = new Car()
            {
                DrivingMode = DrivingMode.Forward
            };

            var result = car.GetDirection();

            StringAssert.Matches(result, new System.Text.RegularExpressions.Regex("Forward"));
        }
        #endregion


        #region Exception

        [ExpectedException(typeof(NotImplementedException))]
        [TestMethod]
        public void Accelerate_CarHonda_ThrowException()
        {
            var car = new Car()
            {
                Type = CarType.Honda
            };

            car.Accelerate();
        }

        #endregion
    }
}
