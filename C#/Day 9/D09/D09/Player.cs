using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    /// <summary>
    /// Subscriber 
    /// </summary>
    internal class Player
    {
        public string Name { get; set; }
        public string Team { get; set; }


        ///Define Callback Method matching event delegate datatype (Signature)
        public void Run(Location D)
        {
            Console.WriteLine($"Player {Name} is Running with Delta {D}.....");
        }
    }
}
