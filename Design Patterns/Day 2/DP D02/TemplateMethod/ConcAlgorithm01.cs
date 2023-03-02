using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TemplateMethod
{
    internal class ConcAlgorithm01:ABSAlgorithm
    {
        /// <summary>
        /// let Subclasses to redifine certain steps from Algorithm
        /// without any change to Algorithm Structor
        /// </summary>
        public override void LoadData()
        {
            Console.WriteLine("Load from DB");
        }

        public override void SaveResults()
        {
            Console.WriteLine("Save into DB");
        }
    }
}
