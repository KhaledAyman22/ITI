namespace Task_1
{
    public class Student
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public double Grade { get; set; }
        public string ImagePath { get; set; }

        public Student(int id, string name, int age, double grade)
        {
            Id = id;
            Name = name;
            Age = age;
            Grade = grade;
            ImagePath = "https://images.unsplash.com/photo-1500648767791-00dcc994a43e?ixlib=rb-4.0.3&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8cGVvcGxlJTIwZmFjZXxlbnwwfHwwfHw%3D&w=1000&q=80";
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
