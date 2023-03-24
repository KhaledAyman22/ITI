using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models
{
    public class Branch
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }

        public virtual Department Department { get; set; } = new();
    }
}