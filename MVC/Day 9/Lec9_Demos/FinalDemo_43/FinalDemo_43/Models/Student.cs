using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Xml.Linq;

namespace FinalDemo_43.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[a-zA-Z]+", ErrorMessage = "Name Must be only characters")]
        [Display(Name = "Student Name")]
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Range(20, 60)]
        public int Age { get; set; }

        public Gender Gender { get; set; }

        public bool IsActive { get; set; }

        [ForeignKey("Department")]
        public int DeptId { get; set; }

        public virtual Department Department { get; set; }

    }

    public enum Gender { Male, Female }
}
