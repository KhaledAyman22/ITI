using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs
{
    public class DepartmentDTO
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public ICollection<BranchDTO>? Branches { get; set; }

        public ICollection<InstructorDTO>? Instructors { get; set; }
    }
}
