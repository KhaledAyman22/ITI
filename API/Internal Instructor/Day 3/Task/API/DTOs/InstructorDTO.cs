using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class InstructorDTO
    {
        public int? Id { get; set; }

        public string Ssn { get; set; } = string.Empty;

        [MaxLength(30)]
        [RegularExpression("^\\w$")]
        public string Name { get; set; } = string.Empty;

        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;

        [Range(20, 70)]
        public int Age { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        [ForeignKey("Department")]
        public int DepartmentId { get; set; }
    }
}
