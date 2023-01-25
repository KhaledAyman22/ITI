using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class ChooseAllQuestion: Question
    {
        public ChooseAllQuestion(string header, string body, double marks, AnswerList choices, AnswerList modelAnswer) 
            : base(header, body, marks, choices, modelAnswer)
        {}

        public override AnswerList ReadAnswer()
        {
            string[] ans = Console.ReadLine().Split(',');

            AnswerList answer = new AnswerList();

            for (int i = 0; i < ans.Length; i++)
            {
                if (ans[i][0] == 'a') answer.Add(Choices[0]);
                else if (ans[i][0] == 'b') answer.Add(Choices[1]);
                else if (ans[i][0] == 'c') answer.Add(Choices[2]);
                else if (ans[i][0] == 'd') answer.Add(Choices[3]);
            }

            if(answer.Count== 0) return null;
            return answer;
        }
    }
}
