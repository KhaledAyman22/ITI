using Task_2.Models;

namespace Task_2.ViewModels
{
    public class CourseStudentsViewModel
    {
        public List<Student> Students { get; set; } = new();
        public Course Course { get; set; } = new();
    }
}
