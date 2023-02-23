using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Strategy_DP.StategyDP
{
    public abstract class IQuackBehavior
    {
        public abstract void PerformQuack();
    }

    public class Quack : IQuackBehavior
    {
        public override void PerformQuack()
        {
            Console.WriteLine("Quacking");
            Console.Beep();
        }
    }

    public class Sqeek : IQuackBehavior
    {
        public override void PerformQuack()
        {
            Console.WriteLine("Sqeek");
            Console.Beep(32767, 1500);
        }
    }

}
