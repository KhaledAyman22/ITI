using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCLegacyTrials
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (TempFile T = new TempFile())
            //{
            //    T.DoSomeWork();
            //}
            ///Generated code
            ///try 
            ///{T.DoSomeWork()}
            ///Finally
            ///{T.Dispose();}

            //T.DeleteFile();
            //T.Dispose();


            TempFile T01 = new TempFile();
            T01.DoSomeWork();

            T01 = null; ///T01 UnReachable object in Heap

            GC.Collect();
            GC.WaitForPendingFinalizers();
            ///wait for Destructors to finish

            Console.WriteLine( "End of Program" );
        }
    }
}
