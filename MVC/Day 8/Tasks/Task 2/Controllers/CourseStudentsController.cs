using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Linq;
using Task_2.Models;
using Task_2.ViewModels;

namespace Task_2.Controllers
{
    public class CourseStudentsController : Controller
    {
        private readonly StudentCourseContext _context;

        public CourseStudentsController(StudentCourseContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(int id)
        {
            if (_context.Courses is null)
                return Problem("Entity set 'StudentCourseContext.Courses'  is null.");

            var course = await _context.Courses.Include(c => c.Students)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            return course is null ? Problem("No course with given Id.") : View(course);
        }

        public async Task<IActionResult> Edit(int id)
        {

            var course = await _context.Courses.Include(c => c.Students)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (course is null) return Problem("Course is null.");

            CourseStudentsViewModel viewModel = new()
            {
                Course = course,
                Students = await _context.Students.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int[] selectedIds)
        {
            var course = await _context.Courses.Include(c => c.Students)
                                        .FirstOrDefaultAsync(c => c.Id == id);

            if (course is null) return Problem("Student is null.");

            var selected = _context.Students.Where(s => selectedIds.Contains(s.Id)).ToList();

            var crntExceptSelected = course.Students.Except(selected).ToList();
            var crntIntersectSelected = course.Students.Intersect(selected).ToList();
            var newCrnt = selected.Except(crntIntersectSelected).ToList();

            foreach (var student in crntExceptSelected)
                course.Students.Remove(student);

            course.Students.AddRange(newCrnt);

            _context.SaveChanges();

            return RedirectToAction("Index", new { id = course.Id });
        }

    }
}
