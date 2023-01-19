using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D04_PII
{
    internal class NegativeNumberException : Exception
    {
        public NegativeNumberException():base("Negative Number")
        {

        }
    }
}
