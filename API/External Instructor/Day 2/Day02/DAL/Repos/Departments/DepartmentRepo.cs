using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Departments
{
    public class DepartmentRepo : IDepartmentRepo
    {
        private readonly APIDay02Context _context;

        public DepartmentRepo(APIDay02Context context)
        {
            _context = context;
        }

        public Department? GetDepartmentWithTicketsAndDevCount(int id)
        {
            var dep = _context.Departments.Include(d => d.Tickets)
                .ThenInclude(t => t.Developers).FirstOrDefault(d => d.Id == id);

            return dep;
        }
    }
}
