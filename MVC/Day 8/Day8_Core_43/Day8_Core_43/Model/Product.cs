using System.ComponentModel.DataAnnotations;

namespace Day8_Core_43.Model
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(30, ErrorMessage = "Too long name!!")]
        public string Name { get; set; }

        public double Price { get; set; }
    }
}
