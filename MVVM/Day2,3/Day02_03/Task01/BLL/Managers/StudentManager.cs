using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BLL.UIModels;
using Task01.DAL;
using Task01.DAL.Models;
using Task01.DAL.Repos;

namespace Task01.BLL.Managers
{
    public class StudentManager : IStudentManager
    {
        private readonly IStudentRepo _studentRepo;

        public StudentManager(IStudentRepo studentRepo)
        {
            _studentRepo = studentRepo;
        }

        public void Add(Student_UI student)
        {
            _studentRepo.Add(new()
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Age = student.Age,
            });

            _studentRepo.Save();
        }

        public void Delete(int id)
        {
            _studentRepo.Delete(id);
            _studentRepo.Save();
        }

        public Student_UI? Get(int id)
        {
            var std = _studentRepo.Get(id);
            
            if (std == null) return null;

            return new() { 
                Id = std.Id,
                Name = std.Name,
                Address = std.Address,
                Age = std.Age,
            };
        }

        public IEnumerable<Student_UI>? GetAll()
        {
            return _studentRepo.GetAll()?.Select(s => new Student_UI()
            {
                Id = s.Id,
                Name = s.Name,
                Address = s.Address,
                Age = s.Age,
            });
        }

        public void Update(Student_UI student)
        {
            _studentRepo.Update(new()
            {
                Id = student.Id,
                Name = student.Name,
                Address = student.Address,
                Age = student.Age,
            });
            _studentRepo.Save();
        }
    }
}
