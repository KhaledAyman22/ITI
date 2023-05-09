using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    public class NegativeNumbersEncounteredException:Exception
    {
        public NegativeNumbersEncounteredException(string message): base(message)
        {
        }
    }
}
