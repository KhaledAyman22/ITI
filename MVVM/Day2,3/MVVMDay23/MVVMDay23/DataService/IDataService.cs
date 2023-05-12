using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.DataService
{
    public interface IDataService
    {
        IEnumerable<Student> GetAll();
        Student Get(int id);
        void Add(Student student);
        void Update(Student student);
        void Delete(int id);


    }
}
