using System.ComponentModel.DataAnnotations;

namespace API.DTOs
{
    public class RegisterDTO
    {
        [MaxLength(30)]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [RegularExpression("^(?=.*[A-Z])(?=.*[a-z])(?=.*[0-9])(?=.*[!@#\\$%\\^&\\*])(?=.{6,30}).*$",
            ErrorMessage = "Password must consist of at least one upeercase, one lowercase, one special character, and numbers with a minimum length of 6 and a max of 30.")]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;
    }
}
