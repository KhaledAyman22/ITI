using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Departments
{
    public interface IDepartmentRepo
    {
        public Department? GetDepartmentWithTicketsAndDevCount(int id);
    }
}
