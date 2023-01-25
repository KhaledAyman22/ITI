using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class TrueFalseQuestion:Question
    {
        public TrueFalseQuestion(string header, string body, double marks, AnswerList choices, Answer modelAnswer) 
            : base(header, body, marks, choices, modelAnswer)
        {}

        public override Answer ReadAnswer()
        {
            string ans = Console.ReadLine();


            if (ans[0] == 'a') return Choices[0];
            else if (ans[0] == 'b') return Choices[1];


            return null;
        }
    }
}
