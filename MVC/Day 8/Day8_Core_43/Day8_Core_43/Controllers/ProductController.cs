using Day8_Core_43.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Day8_Core_43.Controllers
{
    public class ProductController : Controller
    {
        //ProductDbContext dbContext = new ProductDbContext();


        //request service of type ProductDbContext ==> "inject service in ctor"
        public ProductDbContext Context { get; }
        public ProductController(ProductDbContext context)
        {
            Context = context;
        }

        public string calc(int x, int y)
        {
            return (x+y).ToString();
        }

        // GET: ProductController
        public ActionResult Index()
        {
            //return View(ProductList.Products.ToList());
            return View(Context.Products.ToList());
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(Product prod)
        {
            try
            {
                //ProductList.Products.Add(prod);

                Context.Products.Add(prod);
                Context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
