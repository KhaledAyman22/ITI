using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal abstract class Question
    {
        public string Header { get; set; }

        public string Body { get; set; }
        
        public double Marks { get; set; }

        public virtual AnswerList Choices { get; set; }

        public object ModelAnswer { get; set; }

        protected Question(string header, string body, double marks, AnswerList choices, object modelAnswer)
        {
            Header = header;
            Body = body;
            Marks = marks;
            Choices = choices;
            ModelAnswer = modelAnswer;
        }

        public override string ToString()
        {
            string str = "Mark";
            if (Marks > 1) str = "Marks";
            return $"{Header}\t({Marks} {str})\n\n{Choices}";
        }

        public abstract object ReadAnswer();
    }
}
