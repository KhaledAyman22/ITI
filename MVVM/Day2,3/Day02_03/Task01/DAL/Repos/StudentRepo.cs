using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.DAL.Models;

namespace Task01.DAL.Repos
{
    internal class StudentRepo : IStudentRepo
    {
        private readonly MyDbContext _context;

        public StudentRepo(MyDbContext context)
        {
            _context = context;
        }

        public void Add(Student student)
        {
            _context.Add(student);
        }

        public void Delete(int id)
        {
            var student = _context.Students.Find(id);
            
            if (student is null) return;
            
            _context.Remove(student);
        }

        public Student? Get(int id)
        {
            return _context.Students.Find(id);
        }

        public IEnumerable<Student> GetAll()
        {
            return _context.Students.AsNoTracking().ToList();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Update(Student student)
        {
            _context.Update(student);
        }
    }
}
