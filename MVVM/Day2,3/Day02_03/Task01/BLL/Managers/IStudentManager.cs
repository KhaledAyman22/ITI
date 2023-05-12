using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task01.BLL.UIModels;
using Task01.DAL.Models;

namespace Task01.BLL.Managers
{
    public interface IStudentManager
    {
        IEnumerable<Student_UI>? GetAll();
        Student_UI? Get(int id);
        void Add(Student_UI student);
        void Update(Student_UI student);
        void Delete(int id);
    }
}
