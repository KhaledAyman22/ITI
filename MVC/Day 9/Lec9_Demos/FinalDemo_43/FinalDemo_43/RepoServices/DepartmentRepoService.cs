using FinalDemo_43.Models;
using System.Collections.Generic;
using System.Linq;

namespace FinalDemo_43.RepoServices
{
    public class DepartmentRepoService : IDepartmentRepository
    {
        public MainDbContext context { get; }
        public DepartmentRepoService(MainDbContext context)
        {
            this.context = context;
        }
        public List<Department> GetAll()
        {
            return context.Departments.ToList();
        }

        public Department GetDetails(int id)
        {
            return context.Departments.Find(id);
        }

        public void Insert(Department dept)
        {
            context.Departments.Add(dept);
            context.SaveChanges();
        }

        public void UpdateDept(int id, Department dept)
        {
            Department deptUpdated = context.Departments.Find(id);
            deptUpdated.Name = dept.Name;

            context.SaveChanges();
        }

        public void DeleteDept(int id)
        {
            context.Remove(context.Departments.Find(id));
            context.SaveChanges();
        }
    }
}
