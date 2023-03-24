using System;
using System.Collections.Generic;
using System.Linq;
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
    public class InstructorsController : ControllerBase
    {
        private readonly InstDepContext _context;

        public InstructorsController(InstDepContext context)
        {
            _context = context;
        }

        // GET: api/Instructors
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InstructorDTO>>> GetInstructors()
        {
            if (_context.Instructors == null)
            {
                return NotFound();
            }
            
            return await _context.Instructors.Select(i => new InstructorDTO()
            {
                Id = i.Id,
                Ssn = i.Ssn,
                Name = i.Name,
                Address = i.Address,
                Age = i.Age,
                DepartmentId = i.DepartmentId,
                Salary = i.Salary,
                Birthdate = i.Birthdate,
                Email = i.Email,
                Phone = i.Phone,
            }).ToListAsync();
        }

        // GET: api/Instructors/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InstructorDTO>> GetInstructor(int id)
        {
          if (_context.Instructors == null)
          {
              return NotFound();
          }
            var instructor = await _context.Instructors.FindAsync(id);

            if (instructor == null)
            {
                return NotFound();
            }

            return new InstructorDTO()
            {
                Ssn = instructor.Ssn,
                Name = instructor.Name,
                Address = instructor.Address,
                Age = instructor.Age,
                DepartmentId = instructor.DepartmentId,
                Salary = instructor.Salary,
                Birthdate = instructor.Birthdate,
                Email = instructor.Email,
                Phone = instructor.Phone
            };
        }

        // PUT: api/Instructors/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInstructor(int id, InstructorDTO instructor)
        {
            if (!InstructorExists(id))
            {
                return NotFound();
            }

            var dep = _context.Departments.Find(instructor.DepartmentId);
            if (dep is null)
                return NotFound("No Department with the given Id");

            Instructor i = new()
            {
                Ssn = instructor.Ssn,
                Name = instructor.Name,
                Address = instructor.Address,
                Age = instructor.Age,
                Department = dep,
                Salary = instructor.Salary,
                Birthdate = instructor.Birthdate,
                Email = instructor.Email,
                Phone = instructor.Phone,
            };

            _context.Entry(i).State = EntityState.Modified;

            await _context.SaveChangesAsync();
            
            return NoContent();
        }

        // POST: api/Instructors
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<InstructorDTO>> PostInstructor(InstructorDTO instructor)
        {
            if (_context.Instructors == null)
            {
                return Problem("Entity set 'InstDepContext.Instructors'  is null.");
            }

            var dep = _context.Departments.Find(instructor.DepartmentId);
            if (dep is null) 
                return NotFound("No Department with the given Id");

            var inst = new Instructor()
            {
                Ssn = instructor.Ssn,
                Name = instructor.Name,
                Address = instructor.Address,
                Age = instructor.Age,
                Department = dep,
                Salary = instructor.Salary,
                Birthdate = instructor.Birthdate,
                Email = instructor.Email,
                Phone = instructor.Phone,
                Password = instructor.Password,
            };

            await _context.Instructors.AddAsync(inst);
            await _context.SaveChangesAsync();
            
            instructor.Id = inst.Id;

            return CreatedAtAction("GetInstructor", new { id = inst.Id }, instructor);
        }

        // DELETE: api/Instructors/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInstructor(int id)
        {
            if (_context.Instructors == null)
            {
                return NotFound();
            }
            var instructor = await _context.Instructors.FindAsync(id);
            if (instructor == null)
            {
                return NotFound();
            }

            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InstructorExists(int id)
        {
            return (_context.Instructors?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
