using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Actor
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression("^\\w+$")]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public Gender Gender { get; set; }

        [Required]
        [Range(15, 90)]
        public int Age { get; set; }
        
        public string Address { get; set; } = string.Empty;
        
        [Required]
        [DataType(DataType.Currency)]
        public decimal Wage { get; set; }
        
        
        public virtual ICollection<Movie> Movies { get; set; } = new List<Movie>();
    }
}