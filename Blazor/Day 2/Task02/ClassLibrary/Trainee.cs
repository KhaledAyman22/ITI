using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public int ID { get; set; }
        [RegularExpression("^[a-zA-Z]+( [a-zA-Z]+)?$", ErrorMessage = "Name should contain at least one sequence of charachters and a max of 2 separated by single space")]
        public string Name { get; set; } = string.Empty;
        public Gender Gender { get; set; }
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Phone]
        public string MobileNo { get; set; } = string.Empty;
        public DateTime Birthdate { get; set; }
        [ForeignKey("Track")]
        public int TrackID { get; set; }
        Track? Track { get; set; }
    }
}
