using MVVMDay23.DataAccess;
using MVVMDay23.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMDay23.DataService
{
    public class StudentDataService : IDataService
    {
        public void Add(Student student)
        {
            using (SchoolDbContext Context = new())
            {
                if(student !=null)
                Context.Students.Add(student);
                Context.SaveChanges();
               
            }
        }

        public void Delete(int id)
        {
            using (SchoolDbContext schoolDbContext = new SchoolDbContext())
            {
                var Student = schoolDbContext.Students.FirstOrDefault(s => s.Id == id);
                if(Student != null)
                    schoolDbContext.Students.Remove(Student);
                schoolDbContext.SaveChanges();
            }
        }

        public Student Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Student> GetAll()
        {
           using(SchoolDbContext Context=new())
            {
                Context.Database.EnsureCreated();
                return Context.Students.ToList();
            }
        }

        public void Update(Student student)
        {
            using (SchoolDbContext Context = new())
            {


                var StudentUpdate =Context.Students.FirstOrDefault(s=>s.Id== student.Id);
                if(StudentUpdate != null)
                {
                    StudentUpdate.Name=student.Name;
                    StudentUpdate.Address=student.Address;
                    StudentUpdate.Age=student.Age;
                    Context.SaveChanges();
                }
                   
            }
            
        }
    }
}
