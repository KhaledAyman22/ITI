using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class ChooseOneQuestion:Question
    {
        
        public ChooseOneQuestion(string header, string body, double marks, AnswerList choices, Answer modelAnswer) 
            : base(header, body, marks, choices, modelAnswer)
        {}

        public override Answer ReadAnswer()
        {
            string ans = Console.ReadLine();

            if ('a' <= ans[0] && ans[0] <= 'd')
            {
                if (ans[0] == 'a') return Choices[0];
                else if (ans[0] == 'b') return Choices[1];
                else if (ans[0] == 'c') return Choices[2];
                else if (ans[0] == 'd') return Choices[3];
            }

            return null;
        }
    }
}
