using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    /// <summary>
    /// Subsc.
    /// </summary>
    internal class Referee
    {
        public string Name { get; set; }

        ///Call Back Method
        public void Follow (Location Delta)
        {
            Console.WriteLine($"Referee {Name} is following the Ball ...");
        }
    }
}
