using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_DP.No_DP
{
    public abstract class Duck
    {
        public void Swim() => Console.WriteLine("Duck is Swimming ");

        public void Fly() => Console.WriteLine("Fly with Normal Speed");

        public void Quack ()
        {
            Console.WriteLine("Quacking");
            Console.Beep();
        }

        public abstract void Display();
    }
}
