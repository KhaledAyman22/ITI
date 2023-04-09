using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using API.Models;

namespace API.DTOs
{
    public class BranchDTO
    {
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        public int DepartmentId { get; set; }
    }
}
