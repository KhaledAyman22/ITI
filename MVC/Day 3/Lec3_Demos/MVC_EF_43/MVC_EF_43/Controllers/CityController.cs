using MVC_EF_43.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_EF_43.Controllers
{
    public class CityController : Controller
    {

        EMPLOYEESEntities context = new EMPLOYEESEntities();  //Context

        // GET: City
        public ActionResult Index()
        {
            return View(context.Cities.ToList());
        }

        // GET: City/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: City/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: City/Create
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

        // GET: City/Edit/5
        public ActionResult Edit(int id)
        {
            City city = context.Cities.Find(id);

            ViewBag.countries = context.Countries.ToList();

            return View(city);
        }

        //// POST: City/Edit/5
        //[HttpPost]      
        //public ActionResult Edit(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        City city = context.Cities.Find(id);
        //        city.CityName = collection["CityName"];
        //        city.cID = int.Parse(collection["cID"]);

        //        context.SaveChanges();

        //        return RedirectToAction("Index");

        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        // POST: City/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, City cty)
        {
            try
            {
                City city = context.Cities.Find(id);
                city.CityName = cty.CityName;
                city.cID = cty.cID;

                context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: City/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: City/Delete/5
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
