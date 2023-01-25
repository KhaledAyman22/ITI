using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    class Parent
    {
        int x;

        protected int y;

        public int Z;

        public Parent()
        {
            x = 1; y = 2;Z = 3;
        }
        public Parent(int _X , int _y , int _Z)
        {
            x = _X;
            y = _y;
            Z = _Z;
        }
        public int Sum () {  return x + y+ Z; }
    }

    class Derived : Parent
    {
        int K;

        public Derived() ///implicity chain to Base parameterless ctor
        {
            K = 4;
        }

        public Derived(int _x , int _y , int _Z , int _K):base(_x , _y , _Z)
        {
            K = _K;
        }

        public int Sum ()
        {
            return K + base.Sum();
        }


    }
}
