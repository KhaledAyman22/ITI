using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    class FibSeries : ISeries
    {
        int current = 1;
        int prev = 0;

        public int Current {  get { return current; } }

        public void MoveNext()
        {
            int Temp = current;
            current = prev+current;
            prev = Temp;
        }

        public void Reset()
        {
            current = 1;
            prev = 0;
        }
    }
}
