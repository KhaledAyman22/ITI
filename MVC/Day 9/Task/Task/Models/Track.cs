using System.ComponentModel.DataAnnotations;

namespace FinalTask.Models
{
    public class Track
    {
        public int Id { get; set; }
        
        [MaxLength(50)]        
        public string Name { get; set; } = string.Empty;

        [MaxLength(200)]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; } = string.Empty;

        public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
    }
}
 