using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D07
{
    internal class PointComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            if ((x is Point L) && (y is Point R))
                return Math.Sqrt(L.X * L.X + L.Y * L.Y).CompareTo
                    (Math.Sqrt(R.X * R.X + R.Y * R.Y));
            ///Check for Nulls ...
            return 1;
        }
    }
}
