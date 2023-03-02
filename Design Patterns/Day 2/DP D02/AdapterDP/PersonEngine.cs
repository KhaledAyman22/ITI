using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDP
{
    internal class PersonEngine
    {
        public static void ProcessPerson (Person person)
        {
            Console.WriteLine($"{person.ID},{person.FullName},{person.AnnualAlary}");
        }
    }
}
