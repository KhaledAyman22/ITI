using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using FirstMVCApp_43.Models;

namespace FirstMVCApp_43.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult getAll()
        {
            List<Employee> empLst = EmployeeList.Employees;

            ViewBag.Emps = empLst;

            return View();
        }

        public ActionResult getById(int id)
        {
            ViewBag.selectedEmp = EmployeeList.Employees.FirstOrDefault(e => e.ID == id);

            return View();
        }

        public ActionResult Edit(int id)
        {
            ViewBag.selectedEmp = EmployeeList.Employees.FirstOrDefault(e => e.ID == id);

            return View();
        }

        [HttpPost]
        public ActionResult Edit(int id, string name, int age, string email)
        {
            Employee edidtedEmp = EmployeeList.Employees.FirstOrDefault(e => e.ID == id);

            edidtedEmp.Name = name;
            edidtedEmp.Age = age;
            edidtedEmp.Email = email;
                
            return RedirectToAction("getAll");
        }


        public ActionResult delete(int id)
        {
            var deletedEmp = EmployeeList.Employees.FirstOrDefault(e => e.ID == id);
            EmployeeList.Employees.Remove(deletedEmp);

            //return getAll();

            return RedirectToAction("getAll");
            //return View("getAll");
        }
    }
}