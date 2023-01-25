using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    abstract class ClassOne
    {
        int x;
        public int X { get => x; set => x = value; }

        public ClassOne(int _X)
        {
            x = _X;
        }

        public void Show() { Console.WriteLine("Non Virtual Show"); }

        public virtual void DynShow() { Console.WriteLine("Virtual Show"); }

        public abstract void DemoFun();

        public abstract int MyProp { get; set; }
    }

    class ClassTwo : ClassOne
    {

        public ClassTwo(int Q):base(Q)
        {

        }

        public override void DemoFun()
        {
            Console.WriteLine("Class Two Demo Fun");
        }
        public override int MyProp { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }

    abstract class X
    {
        public abstract void A();
        public abstract void B();

    }

    abstract class Y : X
    {
        public override void A()
        {
            Console.WriteLine("YA");
        }
    }

    class Z : Y
    {
        ///Must
        public override void B()
        {
            Console.WriteLine("ZB");
        }

        ///optional
        public override void A()
        {
            Console.WriteLine("ZA");
        }
    }




}
