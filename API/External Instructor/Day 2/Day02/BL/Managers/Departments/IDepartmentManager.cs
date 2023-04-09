using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.Dtos;
using BL.Dtos.Department;

namespace BL.Managers.Departments
{
    public interface IDepartmentManager
    {
        public ReadDepartmentWithTicketsAndDevsCountDto? GetDepartmentWithTicketsAndDevCount(int id);
    }
}
