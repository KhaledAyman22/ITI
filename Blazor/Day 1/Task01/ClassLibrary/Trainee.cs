using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public enum Gender
    {
        Male = 0, Female = 1
    }

    public class Trainee
    {
        public string ID { get; set; } = string.Empty;
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)?$", ErrorMessage = "Name should contain at least one sequence of charachters and a max of 2 separated by single space")]
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string MobileNo { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
    }
}
