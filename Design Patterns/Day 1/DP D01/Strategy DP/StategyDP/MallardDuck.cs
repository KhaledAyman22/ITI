using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_DP.StategyDP
{
    public class MallardDuck : Duck
    {

        public MallardDuck():base (new NormalFly() , new Quack())
        {

        }

        public override void Display() => Console.WriteLine("I am Mallard Duck");
    }
}
