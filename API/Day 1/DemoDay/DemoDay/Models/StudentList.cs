namespace DemoDay.Models
{
    public class StudentList
    {
        public static List<Student> students = new List<Student>()
        {
            new Student(){Id = 1 , Name = "Ali" , Address="Giza" , Age=22},
            new Student(){Id = 2 , Name = "Aya" , Address="Ism" , Age=25},
            new Student(){Id = 3 , Name = "Nada" , Address="Alex" , Age=28},
            new Student(){Id = 4 , Name = "Ahmed" , Address="Cairo" , Age=24},
        };
    }
}
