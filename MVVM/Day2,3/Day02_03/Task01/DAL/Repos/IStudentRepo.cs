using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.DAL.Models;

namespace Task01.DAL.Repos
{
    public interface IStudentRepo
    {
        IEnumerable<Student>? GetAll();
        Student? Get(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);
        void Save();
    }
}
