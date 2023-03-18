using FinalDemo_43.Models;
using System.Collections.Generic;

namespace FinalDemo_43.RepoServices
{
    public interface IDepartmentRepository
    {
        public List<Department> GetAll();
        public Department GetDetails(int id);
        public void Insert(Department std);
        public void UpdateDept(int id, Department std);
        public void DeleteDept(int id);
    }
}
