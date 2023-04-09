using System.ComponentModel.DataAnnotations;

namespace Task.Models
{
    public class Movie
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        
        [Required]
        public MovieType Type { get; set; }
        
        [Required]
        [Range(0, 5)]
        public float Duration { get; set; }
        
        [Required]
        public MovieProducer Producer { get; set; }
        
        [Required]
        public int Rate { get; set; }
        
        public virtual ICollection<Actor> Actors { get; set; } = new List<Actor>();
    }
}
