using Task_2.Models;

namespace Task_2.ViewModels
{
    public class StudentCoursesViewModel
    {
        public List<Course> Courses { get; set; } = new();
        public Student Student { get; set; } = new();
    }
}
