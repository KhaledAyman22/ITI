using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class QuestionList : List<Question>
    {
        public string FileName { get; set; }

        public QuestionList(string fileName)
        {
            FileName = fileName; 
        }

        public new void Add(Question question)
        {
            base.Add(question);

            using StreamWriter writer = new StreamWriter($"{FileName}.txt", true);
            writer.WriteLine(question);

        }

        public override string ToString()
        {
            return Helpers.ListToString(this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not QuestionList) return false;
            if (obj == this) return true;


            QuestionList ql = (QuestionList)obj;
            if (Count != ql.Count) return false;

            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(ql[i])) return false;
            }

            return true;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Count, FileName);
        }
    }
}
