using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FinalDemo_43.Models
{
    public class Department
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual List<Student> Student { get; set; }
    }
}
