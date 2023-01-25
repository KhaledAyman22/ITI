using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class FinalExam : Exam
    {
        public double Grade { get; set; }

        public FinalExam(ExamMode mode, DateTime time, int questionsNumber, Subject subject, Dictionary<Question, object> questoinAnswers) 
            : base(mode, time, questionsNumber, subject, questoinAnswers) {}

        public override void ShowExam()
        {
            double grade = 0, total = 0;
            int i = 1;
            foreach (var question in QuestoinAnswers.Keys)
            {
                
                Type questionType = question.GetType();
                char c = 'a';
                
                Console.WriteLine($"{i++}- {question}");

                QuestoinAnswers[question] = question.ReadAnswer();

                if (QuestoinAnswers[question].Equals(question.ModelAnswer))
                    grade += question.Marks;

                total += question.Marks;


                Console.Clear();
            }

            i = 1;
            foreach (var pair in QuestoinAnswers)
            {
                var qt = pair.Key.GetType();

                Console.WriteLine($"{i++}- {pair.Key.Header}");

                Console.WriteLine($"{pair.Value}\n");
            }

            Grade = grade;
            Console.WriteLine($"Grade: {Grade}/{total}");
        }

        public override string ToString()
        {
            return base.ToString() + "Exam Type: Final";
        }
    }
}
