using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    ///Dev01
    interface ISeries
    {
        int Current { get;  }

        void MoveNext();

        void Reset();
    }
}
