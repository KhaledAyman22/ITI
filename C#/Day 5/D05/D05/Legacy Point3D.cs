using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    struct Point3D
    {
        public double XPos { get; set; }
        public double YPos { get; set; }
        public double ZPos { get; set; }


        public static explicit operator Point (Point3D p)
        {
            return new Point()
            {
                X = Convert.ToInt32(p.XPos),
                Y = Convert.ToInt32(p.YPos)
            };
        }

        public override string ToString()
        {
            return $"{XPos}:{YPos}:{ZPos}";
        }

    }
}
