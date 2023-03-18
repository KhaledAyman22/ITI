using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Task_2.Models
{
    public class Student
    {
        public int Id { get; set; }
        
        public string Name { get; set; } = string.Empty;
        
        public Gender Gender { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [DataType(DataType.PhoneNumber)]
        public string PhoneNum { get; set; } = string.Empty;
        
        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public virtual ICollection<Course> Courses { get; } = new List<Course>();
    }
}
