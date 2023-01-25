using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
     class TypeX
    {
    }

    sealed class TypeY:TypeX { }

    //class TypeZ :TypeY { }

    abstract class Demo
    {
        //public sealed void Fun1() { Console.WriteLine(""); } ///not Valid

        public virtual void Fun1() { Console.WriteLine(""); }

        public abstract void Fun02();
    }

    class Demo2:Demo 
    {
        public sealed override void Fun1()
        {
            Console.WriteLine("Sealed Implementation");
        }

        public sealed override void Fun02()
        {
            Console.WriteLine("First & Last Implementation");
        }


    }

    class Demo3: Demo2
    {
        //public override void Fun1() { }
             
    }


}
