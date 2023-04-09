using BL.Dtos.Department;
using DAL.Repos.Departments;
using DAL.Repos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Departments
{
    public class DepartmentManager : IDepartmentManager
    {
        private readonly IDepartmentRepo _departmentRepo;

        public DepartmentManager(IDepartmentRepo departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        public ReadDepartmentWithTicketsAndDevsCountDto? GetDepartmentWithTicketsAndDevCount(int id)
        {
            var dep = _departmentRepo.GetDepartmentWithTicketsAndDevCount(id);

            if (dep is null) return null;

            return new(
                    dep.Id,
                    dep.Name,
                    dep.Tickets.Select(t => 
                        new DepartmentChildTicketDto(t.Id, t.Name, t.Developers.Count))
                );
        }
    }
}
