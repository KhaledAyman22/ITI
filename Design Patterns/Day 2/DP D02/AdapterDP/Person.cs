using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDP
{
    interface  Person
    {
        string ID { get; set; }
        string FullName { get; set; }

        string AnnualAlary { get; set; }
        
    }
}
