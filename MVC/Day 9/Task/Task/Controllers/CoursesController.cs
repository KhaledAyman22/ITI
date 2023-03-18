using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalTask.Models;
using FinalTask.Contracts;
using FinalTask.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Task.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {
        private readonly ICourseRepo _courseRepo;

        public CoursesController(ICourseRepo courseRepo)
        {
            _courseRepo = courseRepo;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var res = _courseRepo.ReadAll();

            return res != null ? 
                          View(res) :
                          Problem("Entity set 'TraineesDbContext.Courses'  is null.");
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var res = _courseRepo.ReadAll();

            if (id == null || res == null)
            {
                return NotFound();
            }

            var course = res.FirstOrDefault(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Topic,Grade")] Course course)
        {
            if (ModelState.IsValid)
            {
                _courseRepo.Create(course);
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var res = _courseRepo.ReadAll();

            if (id == null || res == null)
            {
                return NotFound();
            }

            var course = _courseRepo.Read(id);
            if (course == null)
            {
                return NotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Topic,Grade")] Course course)
        {
            if (id != course.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _courseRepo.Update(id, course);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            var res = _courseRepo.ReadAll();

            if (id == null || res == null)
            {
                return NotFound();
            }

            var course = res.FirstOrDefault(m => m.Id == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var res = _courseRepo.ReadAll();

            if (res == null)
            {
                return Problem("Entity set 'TraineesDbContext.Courses'  is null.");
            }
            var course = _courseRepo.Read(id);
            if (course != null)
            {
                _courseRepo.Delete(course);
            }
            
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
          return (_courseRepo.ReadAll()?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
