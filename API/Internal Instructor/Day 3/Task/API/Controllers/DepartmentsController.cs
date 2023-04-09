using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.DTOs;
using API.Models;

namespace API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly InstDepContext _context;

        public DepartmentsController(InstDepContext context)
        {
            _context = context;
        }

        // GET: api/Departments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartments()
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            return await _context.Departments.Select(d => new DepartmentDTO()
            {
                Name = d.Name,
                Description = d.Description,
                Location = d.Location,
            }).ToListAsync();
        }

        // GET: api/Departments/Detailed
        [HttpGet("Detailed")]
        public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetDepartmentsDetailed()
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }

            await _context.Instructors.LoadAsync();
            await _context.Branches.LoadAsync();

            return await _context.Departments.Select(d => new DepartmentDTO()
            {
                Name = d.Name,
                Description = d.Description,
                Location = d.Location,
                Branches = d.Branches.Select(b => new BranchDTO { Address = b.Address, DepartmentId = b.Id}).ToList(),
                Instructors = d.Instructors.Select(i => new InstructorDTO()
                {
                    Ssn = i.Ssn,
                    Name = i.Name,
                    Address = i.Address,
                    Age = i.Age,
                    DepartmentId = i.DepartmentId,
                    Salary = i.Salary,
                    Birthdate = i.Birthdate,
                    Email = i.Email,
                    Phone = i.Phone,
                    Password = i.Password
                }).ToList()
            }).ToListAsync();
        }

        // GET: api/Departments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var branch = await _context.Departments.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return new DepartmentDTO() {
                Name = branch.Name,
                Description = branch.Description,
                Location = branch.Location,
            };
        }

        // GET: api/Departments/Detailed/5
        [HttpGet("Detailed/{id}")]
        public async Task<ActionResult<DepartmentDTO>> GetDepartmentDetailed(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            await _context.Entry(department).Collection(d => d.Branches).LoadAsync();
            await _context.Entry(department).Collection(d => d.Instructors).LoadAsync();

            return new DepartmentDTO()
            {
                Name = department.Name,
                Description = department.Description,
                Location = department.Location,
                Branches = department.Branches.Select(b => new BranchDTO { Address = b.Address, DepartmentId = b.Id }).ToList(),
                Instructors = department.Instructors.Select(i => new InstructorDTO()
                {
                    Ssn = i.Ssn,
                    Name = i.Name,
                    Address = i.Address,
                    Age = i.Age,
                    DepartmentId = i.DepartmentId,
                    Salary = i.Salary,
                    Birthdate = i.Birthdate,
                    Email = i.Email,
                    Phone = i.Phone,
                    Password = i.Password
                }).ToList()
            };
        }

        // PUT: api/Departments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDepartment(int id, DepartmentDTO department)
        {
            if (!DepartmentExists(id))
            {
                return NotFound();
            }

            Department d = new()
            {
                Id = id,
                Name = department.Name,
                Location = department.Location,
                Description = department.Description
            };

            _context.Entry(d).State = EntityState.Modified;

            await _context.SaveChangesAsync();


            return NoContent();
        }

        // POST: api/Departments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<DepartmentDTO>> PostDepartment(DepartmentDTO department)
        {
            if (_context.Departments == null)
            {
                return Problem("Entity set 'InstDepContext.Departments'  is null.");
            }

            var dep = new Department()
            {
                Name = department.Name,
                Location = department.Location,
                Description = department.Description
            };

            await _context.Departments.AddAsync(dep);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDepartment", new { id = dep.Id }, department);
        }

        // DELETE: api/Departments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            if (_context.Departments == null)
            {
                return NotFound();
            }
            var department = await _context.Departments.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return (_context.Departments?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
