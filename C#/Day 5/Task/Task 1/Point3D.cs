using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_1
{
    internal class Point3D: ICloneable, IComparable<Point3D>
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D()
        {
            X = Y = Z = 0;
        }

        public Point3D(double x, double y, double z):this(x,y)
        {
            Z = z;
        }

        public Point3D(double x, double y):this(x)
        {
            Y = y;
            Z = 0;
        }

        public Point3D(double x)
        {
            X = x;
            Y = 0;
            Z = 0;
        }

        public override string ToString()
        {
            return $"The point coordinates are: ({X},{Y},{Z})";
        }

        public override bool Equals(object? p)
        {
            if(p == null) return false;

            return X == ((Point3D)p).X && Y == ((Point3D)p).Y && Z == ((Point3D)p).Z;
        }

        public object Clone()
        {
            return new Point3D(X, Y, Z);
        }

        public int CompareTo(Point3D? other)
        {
            if(other == null) return -1;

            if(Equals(other)) return 0;

            if (X > other.X) return -1;
            if (X == other.X && Y > other.Y) return -1;
            if (X == other.X && Y == other.Y && Z > other.Z) return -1;


            if (X < other.X) return 1;
            if (X == other.X && Y < other.Y) return 1;
            if (X == other.X && Y == other.Y && Z < other.Z) return 1;

            return -1;
        }

        public static explicit operator string (Point3D point)
        {
            return $"({point.X},{point.Y},{point.Z})";
        }
    }
}
