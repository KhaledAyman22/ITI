//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace D11
//{
//    internal class Point
//    {
//        public int X { get; set; }
//        public int Y { get; set; }

//        public override string ToString() => $"({X},{Y})";

//        //public override int GetHashCode()
//        //{
//        //    return X + Y;
//        //}

//        public override bool Equals(object? obj)
//        {
//            Console.WriteLine("Equals");

//            if ((obj != null) && (obj is Point Right) && (this.GetType() == Right.GetType()))
//            {
//                if (object.ReferenceEquals(this, Right)) return true;
//                return X == Right.X && Y == Right.Y;
//            }
//            return false;
//        }

//        public override int GetHashCode()
//            => HashCode.Combine(X, Y);
//    }
//}
