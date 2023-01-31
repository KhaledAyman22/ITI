using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_PII
{
    public class CustAgent
    {
        public string Name { get; set; }    

        ///CallBackMethod
        public void ContactClient (object sender , EventArgs e)
        {
            if (( sender is BankAccount BC)&& (BC != null))
            {
                Console.WriteLine($"Agent {Name} is Calling Customer {BC.CustName}");
            }
        }
    }
}
