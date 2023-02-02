using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace D10
{
    internal static class Int32Extensions
    {
        public static int Mirror(this int X)
        {
            var cArr = X.ToString().ToCharArray();
            Array.Reverse(cArr);
            if (int.TryParse(new string(cArr), out int R))
                return R;
            return -1;
        }
    }
}
