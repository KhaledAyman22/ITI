//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Text;
//using System.Threading.Tasks;

//namespace D05
//{
//     class Utility
//    {
//        public int X { get; set; }
//        public int Y { get; set; }

//        //public static int counter;///class attribute  

//        static double pi;
//        ///initialzed automatically to default value

//        public static double PI
//        { get { return pi; } }


//        public static double CircleArea(double R)
//        {
//            return PI * R * R;
//        }

//        public Utility()
//        {
//            Console.WriteLine("object ctor");
//        }


//        ///cctor : static ctor
//        ///will be invoked automatically once per PRogram , per class lifetime
//        ///can't have implicit access modifier 
//        ///must be parameterless , no overloading
//        static Utility()
//        {
//            Console.WriteLine("static ctor");
//            pi = 3.1415;
//        }

//        //public static double PI { get; } = 3.1415;

//        public static double Cm2Inch (double Cm)
//        {
//            //this.X = Cm;
//            ///Static method is lacking this Reference
//            ///static method can't DIRECTLY access object members
//            return Cm / 2.54;
//        }

//        public static double Inch2Cm (double Inch) 
//        {
//            return Inch * 2.54;
//        }
    
//        ///valid
//        //public static void FunOne(Utility U)
//        //{
//        //    U.X = 0;
//        //    U.Y = 0;
//        //}
    

    
//    }
//}
