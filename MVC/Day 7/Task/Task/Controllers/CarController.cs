using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Task_1.Models;

namespace Task_1.Controllers
{
    public class CarController : Controller
    {
        public ActionResult Index()
        {
            return RedirectToAction("AllCars");
        }

        public ActionResult AllCars()
        {
            return View(CarList.Cars);
        }

        public ActionResult CarById(int id)
        {
            var car = CarList.Cars.Where(c => c.Num == id).FirstOrDefault();
            return View(car);
        }

        public ActionResult NewCar(Car car)
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCar(Car car)
        {
            CarList.Cars.Add(car);

            return RedirectToAction("AllCars");
        }

        public ActionResult UpdateCar(int id)
        {
            var car = CarList.Cars.Where(c => c.Num == id).FirstOrDefault();
            return View(car);
        }

        [HttpPost]
        public ActionResult UpdateCar(int id, string manufacture, string color, string model)
        {
            var car = CarList.Cars.Where(c => c.Num == id).FirstOrDefault();
            car.Model = model;
            car.Manufacture = manufacture;
            car.Color = color;
            return RedirectToAction("AllCars");
        }

        public ActionResult DeleteCar(int id)
        {
            var car = CarList.Cars.Where(c => c.Num == id).FirstOrDefault();
            return View(car);
        }

        [HttpPost]
        public ActionResult PerformDelete(int id)
        {
            var car = CarList.Cars.Where(c => c.Num == id).FirstOrDefault();
            CarList.Cars.Remove(car);
            return RedirectToAction("AllCars");
        }
    }
}