using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

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

        /*
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

        */
        #region Task
        #region Assert
        [TestMethod]
        public void Brake_TypeBMWVelocity200_Velocity185()
        {
            //Arrange
            var car = new Car
            {
                Type = CarType.BMW,
                Velocity = 200
            };

            var expectedResult = 185;

            //Act
            car.Brake();

            //Assert
            Assert.AreEqual(car.Velocity, expectedResult);
        }

        [TestMethod]
        public void Stop_Velocity200_Velocity0()
        {
            //Arrange
            var car = new Car
            {
                Velocity = 200
            };

            var expectedResult = 0;

            //Act
            car.Stop();

            //Assert
            Assert.AreEqual(car.Velocity, expectedResult);
        }

        [TestMethod]
        public void TwoCars_DifferentInstancesDifferentState_Velocity0()
        {
            //Arrange
            var car1 = new Car
            {
                Velocity = 100
            };

            var car2 = new Car
            {
                Velocity = 200
            };

            //Act
            

            //Assert
            Assert.AreNotSame(car1, car2);
        }

        [TestMethod]
        public void Accelerate_TypeHonda_ThrowsException()
        {
            //Arrange
            var car = new Car { 
                Type = CarType.Honda
            };
            
            //Act

            //Assert
            Assert.ThrowsException<NotImplementedException>(()=> car.Accelerate());
        }
        #endregion

        #region StringAssert
        [TestMethod]
        public void GetDirection_DrivingModeReverse_DirectionReverse()
        {
            //Arrange
            var car = new Car
            {
                DrivingMode = DrivingMode.Reverse
            };

            var expectedResult = "Rev";

            //Act
            var result = car.GetDirection();

            //Assert
            StringAssert.StartsWith(result, expectedResult);
        }

        [TestMethod]
        public void GetDirection_DrivingModeForward_DirectionForward()
        {
            //Arrange
            var car = new Car
            {
                DrivingMode = DrivingMode.Forward
            };

            var pattern = new Regex("^Reverse$");

            //Act
            var result = car.GetDirection();

            //Assert
            StringAssert.DoesNotMatch(result, pattern);
        }
        #endregion
        #endregion
    }
}
