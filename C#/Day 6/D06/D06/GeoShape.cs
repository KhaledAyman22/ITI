using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
     abstract class GeoShape
    {
        int dim1;
        public int Dim01 { get => dim1; set => dim1 = value; }

        int dim2;
        public int Dim02 { get => dim2; set => dim2 = value; }

        public GeoShape(int D1 =0 , int D2 =0)
        {
            Dim01 = D1;
            Dim02 = D2;
        }

        public abstract double CAre { get; }

    }

    class Rect : GeoShape
    {
        public override double CAre => Dim01 * Dim02;
    }
}
