using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class AnswerList:List<Answer>
    {
        public override string ToString()
        {
            return Helpers.ListToString(this);
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if (obj is not AnswerList) return false;
            if (obj == this) return true;


            AnswerList ql = (AnswerList)obj;
            if (Count != ql.Count) return false;

            for (int i = 0; i < Count; i++)
            {
                if (!this[i].Equals(ql[i])) return false;
            }

            return true;
        }
    }
}
