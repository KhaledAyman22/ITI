using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class PracticeExam : Exam
    {
        public PracticeExam(ExamMode mode, DateTime time, int questionsNumber, Subject subject, Dictionary<Question, object> answers) 
            : base(mode, time, questionsNumber, subject, answers){}

        public override void ShowExam()
        {
            int i = 1;
            foreach (var question in QuestoinAnswers.Keys)
            {
                var questionType = question.GetType();
                char c = 'a';

                Console.WriteLine($"{i++}- {question}");

                QuestoinAnswers[question] = question.ReadAnswer();

                Console.Clear();
            }

            i = 1;

            foreach (var question in QuestoinAnswers.Keys)
            {
                var qt = question.GetType();

                Console.WriteLine($"{i++}- {question}");

                Console.WriteLine(question.ModelAnswer);
                Console.WriteLine();
            }
        }

        public override string ToString()
        {
            return base.ToString() + "Exam Type: Practice";
        }
    }
}
