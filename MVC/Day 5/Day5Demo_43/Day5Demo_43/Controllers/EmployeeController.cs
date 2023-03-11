using Day5Demo_43.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day5Demo_43.Controllers
{
    //[AllowAnonymous]
    //[Authorize]
    public class EmployeeController : Controller
    {
        // GET: Employee
        [Route("Emp/main")]
        public ActionResult Index()
        {
            return View(EmployeeList.Employees);
        }

        // GET: Employee/Details/5
        [Route("Emp/{id:int:min(2)}")]
        public ActionResult Details(int id)
        {
            return View(EmployeeList.Employees.Where(e => e.ID == id).FirstOrDefault());
        }

        //[AllowAnonymous]
        // GET: Employee/Create

        [Route("Register/Emp")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        //[AcceptVerbs("GET, DELETE")]
        public ActionResult Create(Employee emp)
        {
            if (string.IsNullOrEmpty(emp.Name))
            {
                ModelState.AddModelError("Name", "You must enter a name!");
            }
            if (emp.Age < 18)
            {
                ModelState.AddModelError("Age", "Age must be +18");
            }

            if (ModelState.IsValid)
            {
                EmployeeList.Employees.Add(emp);
                return RedirectToAction("Index");
            }

            return View();
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
