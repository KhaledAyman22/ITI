using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FinalTask.HelperClasses;

namespace FinalTask.Models
{
    public class Trainee
    {
        public int Id { get; set; }

        [MaxLength(50)]
        public string Name { get; set; } = string.Empty;
        
        public Gender Gender { get; set; }

        [MaxLength(100)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;
        
        [DataType(DataType.PhoneNumber)]
        public string MobileNumber { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public int TrackId { get; set; }

        public int CourseId { get; set; }

        [ForeignKey("TrackId")]
        public virtual Track Track { get; set; } = new();
        
        [ForeignKey("CourseId")]
        public virtual Course Course { get; set; } = new();
    }
}
