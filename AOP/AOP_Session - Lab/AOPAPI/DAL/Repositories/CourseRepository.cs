using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.DAL.Repositories
{
    public class CourseRepository : ICourseRepository
    {

        private readonly Context _context;

        public CourseRepository(Context context)
        {
            _context = context;
        }
        public IEnumerable<Course> GetAll()
        {
            return _context.Courses.ToList();
        }

        public Course GetById(int id)
        {
            return _context.Courses.FirstOrDefault(c => c.ID == id);
        }

        public bool Delete(int courseId)
        {
            return _context.Courses.Remove(GetById(courseId));
        }

    }
}