using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Web.Services.Protocols;

namespace Task.Models
{
    public class Employees
    {
        [Key]
        [RegularExpression("^\\d+$", ErrorMessage = "The id must be a number.")]
        public string Id { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(50, MinimumLength = 6, ErrorMessage = "Name should be between 20 and 50 characters.")]
        [RegularExpression("^(\\w)+ ((\\w)+\\.)? (\\w)+$")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "This field is required.")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Name should be between 20 and 50 characters.")]
        [RegularExpression("^((\\w)|(\\d))+$", ErrorMessage = "Username can contain only alphabetics and numbers.")]
        public string Username { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(30, MinimumLength = 10, ErrorMessage = "Password should be between 10 and 30 characters.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [StringLength(1, ErrorMessage = "Gender must contain only one character.")]
        [RegularExpression("^M|F|m|f$", ErrorMessage = "Gender can only be M or F.")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Currency)]
        public decimal Salary { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime JoinDate { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "This field is required.")]
        [DataType(DataType.EmailAddress)]
        [Compare("Email", ErrorMessage = "Email doesn't match.")]
        [NotMapped]
        public string EmailConfirmation { get; set; }

        [Required]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}