using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace D07
{
    public class Point:IComparable
    {
        public int X { get; set; }
        public int Y { get; set; }

        public int CompareTo(object obj)
        {
            //foreach (var item in (new StackTrace()).GetFrames()) 
            //{
            //    Console.WriteLine(item.GetMethod().Name);
            //}

           if (( obj is Point Right)&&(Right != null))
            {
                if ( X == Right.X)
                    return Y .CompareTo (Right.Y);
                return X.CompareTo (Right.X);
                //{
                //    if (Y > Right.Y) return 1;
                //    else if ( Y < Right.Y) return -1;
                //    else return 0;
                //}
            }
            return 1;
        }

        public override bool Equals(object obj)
        {
           
            Point Right = obj as Point;

            if (Right == null) return false;

            if (this.GetType() != Right.GetType()) return false;

            if ( object.ReferenceEquals(this,Right)) return true;

            return X == Right.X && Y == Right.Y;

        }

        public override string ToString()
        {
            return $"({X},{Y})";
        }
    }

}
