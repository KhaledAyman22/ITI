using FinalDemo_43.Models;
using FinalDemo_43.RepoServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FinalDemo_43.Controllers
{
    public class StudentController : Controller
    {
        //request service of type "IStudentRepository"
        public IStudentRepository StudentRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }

        public StudentController(IStudentRepository studentRepository, IDepartmentRepository departmentRepository)
        {
            StudentRepository = studentRepository;
            DepartmentRepository = departmentRepository;
        }

        // GET: StudentController
        public ActionResult Index()
        {
            return View(StudentRepository.GetAll());
        }

        // GET: StudentController/Details/5
        public ActionResult Details(int id)
        {
            return View(StudentRepository.GetDetails(id));
        }

        // GET: StudentController/Create
        public ActionResult Create()
        {
            ViewBag.depts = DepartmentRepository.GetAll();
            return View();
        }

        // POST: StudentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Student std)
        {
            try
            {
                StudentRepository.Insert(std);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: StudentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StudentController/Edit/5
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

        // GET: StudentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StudentController/Delete/5
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
