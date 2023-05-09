using CarsApp;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class CarStoreTests
    {


        #region Collection Assert
        [TestMethod]
        public void GetAllStoreCars_AddCar_Contains()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            var carStore = new CarStore(new List<Car> { car1, car2, car3});

            var cars = carStore.GetAllStoreCars();

            CollectionAssert.Contains(cars, car1);
        } 

        [TestMethod]
        public void AddCars_AddCarList_IsSubset()
        {
            var car1 = new Car();
            var car2 = new Car();
            var car3 = new Car();
            List<Car> subsetCars= new List<Car>() { car1, car2 };
            var carStore = new CarStore(new List<Car> { car3});

            carStore.AddCars(subsetCars);

            CollectionAssert.IsSubsetOf(subsetCars, carStore.Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_Equal()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car> { car1, car2});
            
            var car3 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car4 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car> { car3, car4});

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEqual(store2Cars, store1Cars);
        }

        [TestMethod]
        public void GetAllStoreCars_SameCarsDifferentOrder_Equivalent()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car> { car1, car2});
            var carStore2 = new CarStore(new List<Car> { car2, car1});

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            CollectionAssert.AreEquivalent(store2Cars, store1Cars);
        }
        #endregion

        #region Assert
        [TestMethod]
        public void GetAllStoreCars_EqualCarsSameOrder_NotEqualCollections()
        {
            // Arrange
            var car1 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car2 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore1 = new CarStore(new List<Car> { car1, car2 });

            var car3 = new Car(CarType.Toyota, 0, DrivingMode.Forward);
            var car4 = new Car(CarType.Audi, 0, DrivingMode.Reverse);
            var carStore2 = new CarStore(new List<Car> { car3, car4 });

            // Act
            var store1Cars = carStore1.GetAllStoreCars();
            var store2Cars = carStore2.GetAllStoreCars();

            // Assert
            Assert.AreNotEqual(store2Cars, store1Cars);
        } 
        #endregion
    }
}
