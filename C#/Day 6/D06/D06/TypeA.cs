using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    class TypeA
    {
        int x;

        public TypeA(int _X)
        {
            x = _X;
        }
        ///Statically Binded Methods
        public void Show()
        {
            Console.WriteLine("I am Base");
        }

        ///using keyword Virtual (or Abstract) <summary>
        /// Dynamically Binded Method
        public virtual void DynShow()
        {
            Console.WriteLine("Base");
        }


    }

    class TypeB:TypeA
    {
        int y;
        public TypeB(int _x =0, int _Y=0):base(_x) {  y = _Y; }

        public new void Show ()
        {
            Console.WriteLine("I am Derived");
        }

        public override void DynShow()
        {
            Console.WriteLine("Derived");
        }
    }

    class TypeC : TypeB
    {
        public override void DynShow()
        {
            Console.WriteLine("TypeC");
        }
    }

    class TypeD : TypeC
    {
        public new void DynShow()
        {
            Console.WriteLine("Type D implementation");
        }
    }

}
