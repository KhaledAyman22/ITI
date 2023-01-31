using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09
{
    internal struct Location
    {
        int x;
        public int X { get => x; set => x = value; }
        int y;
        public int Y { get => y; set => y = value; }
        int z;
        public int Z { get => z; set => z = value; }

        public static bool operator == (Location L , Location R)
        {
            return (L.x == R.x) &&(L.y == R.y)&&(L.z == R.z);
        }

        public static bool operator !=(Location L, Location R)
        {
            return (L.x != R.x) || (L.y != R.y) || (L.z != R.z);
        }

        public static Location operator -(Location L, Location R)
            => new Location()
            {
                x = L.x - R.x,
                y = L.y - R.y,
                z = L.z - R.z
            };


        public override string ToString() => $"({x},{y},{z})";
    }
}
