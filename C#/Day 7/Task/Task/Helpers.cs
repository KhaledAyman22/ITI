using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal static class Helpers
    {
        public static void PrintList<T>(this IList<T> ls)
        {
            int i = 1;
            if(ls == null) return;
            foreach (var item in ls)
            {
                if(item == null) continue;
                Console.WriteLine(i++ + "- " + item.ToString());
            }
        }

        public static string ListToString<T>(this IList<T> ls)
        {
            string s = "";
            char c = 'a';
            foreach (var item in ls)
            {
                s+= $"{c++}- {item}\n";
            }

            return s;
        }
        
        public static List<Question> AddQuestions()
        {
            List<string> files = new List<string>() { "Questions/c++ mcq.txt", "Questions/c++ tf.txt" };//, "Questions/DB_MCQ.txt", "Questions/DB_TF.txt", "Questions/HTML5 mcq.txt", "Questions/HTML5 tf.txt", "Questions/MCQ_JS_Questions.txt", "Questions/T&F_JS_Questions.txt" };

            List<Question> questions = new List<Question>();

            int i = 1, j = 1;

            foreach (var file in files)
            {
                string contents = File.ReadAllText(file);
                var lines = contents.Split("$$$$$$\r\n");
                int k = 0;

                while (k < lines.Length)
                {
                    if (i == 1)
                    {
                        var statment = lines[k][..^2];
                        var c1 = lines[k + 1][..^2];
                        var c2 = lines[k + 2][..^2];
                        var c3 = lines[k + 3][..^2];
                        var c4 = lines[k + 4][..^2];
                        var ans = lines[k + 5][..^2];
                        k += 6;

                        AnswerList answers = new AnswerList() { new Answer(c1), new Answer(c2), new Answer(c3), new Answer(c4) };
                        Answer answer;
                        switch (ans)
                        {
                            case "a": answer = answers[0]; break;
                            case "b": answer = answers[1]; break;
                            case "c": answer = answers[2]; break;
                            default: answer = answers[3]; break;
                        }

                        questions.Add(new ChooseOneQuestion(statment, "", 1, answers, answer));
                    }
                    else
                    {
                        var statment = lines[k][..^2];
                        var ans = lines[k + 1][..^2];
                        k += 2;

                        AnswerList answers = new AnswerList() { new Answer("True"), new Answer("False")};
                        Answer answer;
                        switch (ans)
                        {
                            case "a": answer = answers[0]; break;
                            default: answer = answers[1]; break;
                        }
                        questions.Add(new TrueFalseQuestion(statment, "", 1, answers, answer));
                    }
                }

                i++;

                if (i == 3)
                {
                    i = 1;
                    j++;
                }
            }

            return questions;
        }
    }
}
