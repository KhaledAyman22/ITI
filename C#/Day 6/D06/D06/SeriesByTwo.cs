using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    struct SeriesByTwo : ISeries
    {
        int current;

        public int Current { get { return current; } }

        public void MoveNext()
        {
            current += 2;
        }

        public void Reset()
        {
            current = 0;
        }
    }
}
