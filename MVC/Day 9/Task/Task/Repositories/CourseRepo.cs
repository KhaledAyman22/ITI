using FinalTask.Contracts;
using FinalTask.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace FinalTask.Repositories
{
    public class CourseRepo : ICourseRepo
    {
        private readonly TraineesDbContext _context;

        public CourseRepo(TraineesDbContext context)
        {
            _context = context;
        }

        public bool Create(Course obj)
        {
            try
            {
                _context.Courses.Add(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            _context.SaveChanges();
            return true;
        }

        public Course? Read(int id)
        {
            try
            {
                return _context.Courses.Find(id);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }

        public bool Update(int id, Course obj)
        {
            try
            {
                _context.Update(obj);
                //_context.Tracks.Remove(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }
            _context.SaveChanges();
            return true;
        }
        
        public bool Delete(Course obj)
        {
            try
            {
                _context.Courses.Remove(obj);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                return false;
            }

            _context.SaveChanges();
            return true;
        }

        public ICollection<Course>? ReadAll()
        {
            try
            {
                return _context.Courses.ToList();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return new List<Course>();
        }

        public DbSet<Course>? ReadAllQueryable()
        {
            try
            {
                _context.Courses.Load();
                return _context.Courses;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return null;
        }
    }
}
