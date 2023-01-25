global using System.Diagnostics; /// will be used in ALL Project cs files

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Object; /// can call static members of Object class directly 


namespace D06
{
    class Point
    {
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            #region Is , As Casting
            //Point Right = (Point)obj; //unSafe

            //if (obj is Point) /// return true if valid casting , return false if casting is not valid , will not throw any exceptions
            //{
            //    Point Right = (Point)obj;
            //    return X == Right.X && Y == Right.Y;
            //}

            //if (obj is Point Right) 
            //    return X == Right.X && Y == Right.Y;

            //return false;

            #endregion
            Point Right = obj as Point;
            ///as return null if invalid casting , no exceptions will be thrown

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
