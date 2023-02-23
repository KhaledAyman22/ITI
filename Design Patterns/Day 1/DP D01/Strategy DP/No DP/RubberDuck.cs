using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_DP.No_DP
{
    public class RubberDuck : Duck
    {
        public override void Display() => Console.WriteLine("I am Rubber Duck");

        public new void Fly() => Console.WriteLine("No Wings to Fly");

        public new void Quack ()
        {
            Console.WriteLine("Sqeek");
            Console.Beep(32767, 1500);
        }

    }
}
