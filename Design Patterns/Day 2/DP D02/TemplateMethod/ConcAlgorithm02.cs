using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class ConcAlgorithm02:ABSAlgorithm
    {
        public override void LoadData()
        {
            Console.WriteLine(  "Loading from the Cloud");
        }

        public override void SaveResults()
        {
            Console.WriteLine(  "Saving into the Cloud");
        }

        public override void OptionalStep()
        {
            Console.WriteLine("Ad Hock Method");
        }
    }
}
