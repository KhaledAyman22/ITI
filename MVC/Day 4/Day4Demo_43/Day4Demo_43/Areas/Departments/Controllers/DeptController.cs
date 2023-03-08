using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Day4Demo_43.Areas.Departments.Controllers
{
    public class DeptController : Controller
    {
        // GET: Departments/Dept
        public ActionResult Index()
        {
            return View();
        }

        // GET: Departments/Dept/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Departments/Dept/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Dept/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Departments/Dept/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Departments/Dept/Edit/5
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

        // GET: Departments/Dept/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Departments/Dept/Delete/5
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
