using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITISchoolConsoleApp
{
    public abstract class Person
    {
        public int ID { get; set; }
        public required string FullName { get; set; }

        public bool IsEmployee { get; set; }
    }

    public class Teacher : Person
    {
        [Column(TypeName ="money")]
        public decimal Salary { get; set; }

        public Teacher() => IsEmployee = true;
    }

    public class Student : Person
    {
        public DateTime EnrollmentDate { get; set; }

        public Student() => IsEmployee = false;
    }


}
