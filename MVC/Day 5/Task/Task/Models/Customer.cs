using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Task.CustomHandlers;

namespace Task.Models
{

    public class Customer
    {
        [Key]
        [RegularExpression("^\\d+$", ErrorMessage = "The id must be a number.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name should be between 20 and 50 characters.")] 
        [NameCustomAttribute]
        public string Name { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        public Gender Gender { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}