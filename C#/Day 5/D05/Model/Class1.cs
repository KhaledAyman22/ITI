using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    internal class Class1
    {
        public Class1()
        {
            TypeOne O1 = new();
            O1.z = 1; //internal
            O1.K = 2; //Public 
            O1.L = 3; //internal protected
            //O1.M = 4;
        }
    }

    class TypeTwo : TypeOne
    {
        public TypeTwo()
        {
            this.y = 3; //protected
            this.z = 4; //internal
            this.K = 5; //public
            this.L = 6; //internal protected
            this.M= 7; ///
        }

    }
}
