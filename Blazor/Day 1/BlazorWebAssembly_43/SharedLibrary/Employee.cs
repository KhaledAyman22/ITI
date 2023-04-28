using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Too long FName!!")]
        public string? FirstName { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = "Too long LName!!")]
        public string? LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        public int CountryId { get; set; }

        public virtual Country? Country { get; set; }

        public MaritalStatus MaritalStatus { get; set; }

        public Gender Gender { get; set; }

        public string? Comment { get; set; }

        public DateTime? JoinedDate { get; set; }

        public DateTime? ExitDate { get; set; }
    }
}
