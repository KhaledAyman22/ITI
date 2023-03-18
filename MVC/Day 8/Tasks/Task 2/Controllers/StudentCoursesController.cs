using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using Task_2.Models;
using Task_2.ViewModels;

namespace Task_2.Controllers
{
    public class StudentCoursesController : Controller
    {
        private readonly StudentCourseContext _context;

        public StudentCoursesController(StudentCourseContext context)
        {
            _context = context;
        }

        // GET: StudentCourses
        public async Task<IActionResult> Index(int id)
        {
            if(_context.Students is null) 
                return Problem("Entity set 'StudentCourseContext.Students'  is null.");
            
            var student = await _context.Students.Include(s => s.Courses)
                                        .FirstOrDefaultAsync(s => s.Id == id);

            return student is null ? Problem("No student with given Id.") : View(student);
        }

        public async Task<IActionResult> Edit(int id)
        {
            
            var student = await _context.Students.Include(s => s.Courses)
                                        .FirstOrDefaultAsync(s => s.Id == id);

            if (student is null) return Problem("Student is null.");

            StudentCoursesViewModel viewModel = new()
            {
                Student = student,
                Courses = await _context.Courses.ToListAsync()
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, int[] selectedIds)
        {
            var student = await _context.Students.Include(s => s.Courses)
                                        .FirstOrDefaultAsync(s => s.Id == id);
            
            if (student is null) return Problem("Student is null.");
            
            var selected = _context.Courses.Where(c => selectedIds.Contains(c.Id)).ToList();

            var crntExceptSelected = student.Courses.Except(selected).ToList();
            var crntIntersectSelected = student.Courses.Intersect(selected).ToList();
            var newCrnt = selected.Except(crntIntersectSelected).ToList();

            foreach (var course in crntExceptSelected) 
                student.Courses.Remove(course);

            student.Courses.AddRange(newCrnt);
            
            _context.SaveChanges();

            return RedirectToAction("Index", new { id = student.Id});
        }
    }
}
