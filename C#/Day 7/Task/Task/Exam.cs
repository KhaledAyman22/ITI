using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public enum ExamMode
    {
        Starting = 0, Queued = 1, Finished = 2
    }

    internal abstract class Exam
    {
        public ExamMode Mode { get; set; }
        
        public DateTime Time { get; set; }
        
        public int QuestionsNumber { get; set; }

        public Subject Subject { get; set; }

        public Dictionary<Question,object> QuestoinAnswers { get; set; }

        public Exam(ExamMode mode, DateTime time, int questionsNumber, Subject subject, Dictionary<Question, object> questionAnswers)
        {
            Mode = mode;
            Time = time;
            QuestionsNumber = questionsNumber;
            Subject = subject;
            QuestoinAnswers = questionAnswers;
        }

        public abstract void ShowExam();

        public override string ToString()
        {
            return $"Exam subject: {Subject}, Number of questions: {QuestionsNumber}\nTime: {Time}, Mode: {Mode}";
        }
    }
}
