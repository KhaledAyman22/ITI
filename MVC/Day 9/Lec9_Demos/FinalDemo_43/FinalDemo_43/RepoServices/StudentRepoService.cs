using FinalDemo_43.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalDemo_43.RepoServices
{
    public class StudentRepoService: IStudentRepository
    {
        public MainDbContext Context { get; }

        //request service of type mainDbContext to be injected in Ctor
        public StudentRepoService(MainDbContext context)
        {
            Context = context;
        }
        public List<Student> GetAll()
        {
            return Context.Students.ToList();
        }

        public Student GetDetails(int id)
        {
            return Context.Students.Find(id);
        }

        public void Insert(Student std)
        {
            Context.Students.Add(std);
            Context.SaveChanges();
        }

        public void UpdateStd(int id, Student std)
        {
            Student stdUpdated = Context.Students.Find(id);

            stdUpdated.Name = std.Name;
            stdUpdated.Age = std.Age;
            stdUpdated.Email = std.Email;
            stdUpdated.IsActive = std.IsActive;
            stdUpdated.Password = std.Password;
            stdUpdated.DeptId = std.DeptId;

            Context.SaveChanges();
        }

        public void DeleteStd(int id)
        {
            Context.Remove(Context.Students.Find(id));
            Context.SaveChanges();
        }
    }
}
