using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAppTests
{
    [TestClass]
    public class AssemblyInitializer
    {

        [AssemblyInitialize]
        public static void Initialize(TestContext context) 
        {
            context.WriteLine("Assembly Init");
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup() 
        { 
        }
    }
}
