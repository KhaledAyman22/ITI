using System.ComponentModel.DataAnnotations;

namespace FinalTask.Models
{
    public class Course
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Topic { get; set; } = string.Empty;

        [Range(0, 100)]
        [RegularExpression("^(100(\\.0{1,2})?|[1-9]?\\d(\\.\\d{1,2})?|0(\\.\\d{1,2})?)$")]
        public double Grade { get; set; }

        public virtual ICollection<Trainee> Trainees { get; set; } = new List<Trainee>();
    }
}
