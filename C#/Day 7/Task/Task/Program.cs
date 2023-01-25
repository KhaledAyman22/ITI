namespace Task
{
    internal class Program
    {
        static QuestionList questions = new("C++");

        static List<Subject> subjects = new List<Subject>() { new Subject(name: "C++", description: "A programming course") };

        static Dictionary<Question, object> exam = new Dictionary<Question, object>();
        
        static void Main(string[] args)
        {
            questions.AddRange(Helpers.AddQuestions());
            Populate();
            
            PracticeExam practiceExam = new(0, DateTime.Now, 10, subjects[0], exam);

            FinalExam FinalExam = new(0, DateTime.Now, 10, subjects[0], exam);

            int c;
            do {
                Console.Clear();
                Console.WriteLine("1- Practice\n2- Final");
            }
            while(!int.TryParse(Console.ReadLine(), out c));

            Console.Clear();

            if (c == 1) practiceExam.ShowExam();
            else FinalExam.ShowExam();
        }

        static private void Populate()
        {
            //Random rnd = new Random();
            //questions.OrderBy(x => rnd.Next()).Take(10).ToList().ForEach((q) => exam.Add(q, null));
            Random rnd = new Random();
            List<int> taken = new List<int>();

            for (int i = 0; i < 10; i++)
            {
                int r;
                do { r = rnd.Next(0, questions.Count - 1); }
                while (taken.Contains(r));

                taken.Add(r);
                exam.Add(questions[r], null);
            }
        }
    }
}