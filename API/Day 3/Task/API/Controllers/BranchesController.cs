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
    public class BranchesController : ControllerBase
    {
        private readonly InstDepContext _context;

        public BranchesController(InstDepContext context)
        {
            _context = context;
        }

        // GET: api/Branches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BranchDTO>>> GetBranches()
        {
            if (_context.Branches == null)
            {
              return NotFound("a7a");
            }
            
            return await _context.Branches.Select(b => new BranchDTO() 
            {
                Address = b.Address,
                DepartmentId = b.DepartmentId  
            }).ToListAsync();
        }

        // GET: api/Branches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BranchDTO>> GetBranch(int id)
        {
            if (_context.Branches == null)
            {
                return NotFound();
            }
            var branch = await _context.Branches.FindAsync(id);

            if (branch == null)
            {
                return NotFound();
            }

            return new BranchDTO() { Address = branch.Address, DepartmentId = branch.DepartmentId };
        }

        // PUT: api/Branches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBranch(int id, BranchDTO branch)
        {
            if (!BranchExists(id))
            {
                return NotFound();
            }

            var dep = _context.Departments.Find(branch  .DepartmentId);
            if (dep is null)
                return NotFound("No Department with the given Id");

            Branch b = new()
            {
                Id = id,
                Address = branch.Address,
                Department = dep,
            };

            _context.Entry(b).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/Branches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BranchDTO>> PostBranch(BranchDTO branch)
        {
            if (_context.Branches == null)
            {
                return Problem("Entity set 'InstDepContext.Branches'  is null.");
            }

            var dep = _context.Departments.Find(branch.DepartmentId);
            if (dep is null)
                return NotFound("No Department with the given Id");

            var br = new Branch()
            {
                Address = branch.Address,
                Department = dep
            };

            await _context.Branches.AddAsync(br);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBranch", new { id = br.Id }, branch);
        }

        // DELETE: api/Branches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            if (_context.Branches == null)
            {
                return NotFound();
            }
            var branch = await _context.Branches.FindAsync(id);
            if (branch == null)
            {
                return NotFound();
            }

            _context.Branches.Remove(branch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BranchExists(int id)
        {
            return (_context.Branches?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
