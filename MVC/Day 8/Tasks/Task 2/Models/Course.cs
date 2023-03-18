using System.Collections.ObjectModel;

namespace Task_2.Models
{
    public class Course
    {
        public int Id { get; set; }
       
        public string Topic { get; set; } = string.Empty;
        
        public int CourseGrade { get; set; }

        public virtual ICollection<Student> Students { get; } = new List<Student>();
    }
}
