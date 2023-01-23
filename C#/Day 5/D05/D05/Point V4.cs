using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D05
{
    internal class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        #region Ctors

        ///if no User defined ctor exists , compiler will generate
        ///default parameterless ctor (empty) doing nothing 

        ///if any userdefined ctor exists with any Signature , compiler will no longer 
        ///generate parameterless ctor
        public Point(int _X=0, int _Y=0)
        {
            X = _X;
            Y = _Y;
        }

        ///Copy ctor
        public Point(Point OldP)
        {
            X = OldP.X;
            Y = OldP.Y;
        }

        #endregion

        #region Operator overloading
        ///C# operator overloading must be static method
        ///non overloadable operators : = , [] , ! , new , . , => , -> ,....
        ///compound operators (+= , -= ,... ) supported by default if original operator is implemented

        public static Point operator+ (Point Left , Point Right)
        {
            return new Point()
            {
                X = (Left?.X??0) + (Right?.X??0),
                Y = (Left?.Y??0) + (Right?.Y??0)
            };
        }

        public static Point operator +(Point Left, int Right)
        {
            return new Point()
            {
                X = (Left?.X ?? 0) + Right,
                Y = (Left?.Y ?? 0) + Right
            };
        }

        ///non overloadable
        //public static Point operator +=(Point Left, Point Right)
        //{
        //}

        ///prefix , postfix
        public static Point operator++ (Point P)
        {
            return new()
            {
                X = P.X + 1,
                Y = P.Y + 1
            };
        }

        public static bool operator == (Point Left, Point Right)
        {
            if ((Left != null) && (Right != null))
                return (Left.X == Right.X) && (Left.Y == Right.Y);
            return false;
        }

        public static bool operator !=(Point Left, Point Right)
        {
            throw new NotImplementedException();
        }

        public static explicit operator string (Point P)
        {
            return P.ToString ();
        }

        public static /*implicit*/ explicit operator int (Point P)
        {
            return (int)(Math.Sqrt(P.X * P.X) + Math.Sqrt(P.Y * P.Y));
        }

        #endregion


        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }
}
