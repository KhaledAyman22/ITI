using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    public class FizzBuzz
    {
        #region Version 1
        /*public static string Print(int testingNumber)
        {
            return testingNumber.ToString();
        }*/
        #endregion

        #region Version 2
        /* public static string Print(int testingNumber)
         {

             if (IsBuzz(testingNumber))
                 return "Buzz";

             return testingNumber.ToString();
         }*/
        #endregion

        #region Version 3
        public static string Print(int testingNumber)
        {
            if (IsFizz(testingNumber) && IsBuzz(testingNumber))
                return "FizzBuzz";

            if (IsFizz(testingNumber))
                return "Fizz";

            if (IsBuzz(testingNumber))
                return "Buzz";

            return testingNumber.ToString();
        }
        #endregion

        private static bool IsBuzz(int testingNumber)
        {
            return testingNumber % 5 == 0;
        }

        private  static bool IsFizz(int testingNumber)
        {
            return testingNumber % 3 == 0;  
        }
    }
}
