using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class Department
    {
        public int Id { get; set; }

        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(50)]
        public string Location { get; set; } = string.Empty;

        [MaxLength(100)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Branch> Branches { get; set; } = new List<Branch>();

        public virtual ICollection<Instructor> Instructors { get; set; } = new List<Instructor>();
    }
}
