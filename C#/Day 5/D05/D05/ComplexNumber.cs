using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    internal class ComplexNumber
    {
        int real, imag;

        public int GetReal()
        {
            return real;
        }

        public void SetReal(int R)
        { real = R; }
        ///native version 
        //SetReal (ComplexNumber this , int R) //this : Reference to Caller Object
        //{this.real = R;}
    }
}
