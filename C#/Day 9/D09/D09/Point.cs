using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    internal class Point
    {
        int x;
        public int X { get => x; set => x = value; }
        int y;
        public int Y { get => y; set => y = value; }
        int z;
        public int Z { get => z; set => z = value; }


        public override string ToString() => $"({x},{y},{z})";

    }
}
