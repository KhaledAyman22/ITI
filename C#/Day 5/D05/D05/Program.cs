using Model;
namespace D05
{
    class TypeThree : TypeOne
    {
        public TypeThree()
        {
            this.y = 1; ///Protected
            this.K = 2; /// Public
            this.L = 3; /// outside assembly , inside derived class
            //this.M = 4; //not valid as class TypeThree is from diff assembly file
        }
    }

    internal class Program
    {

        public static void DemoFun (ref Point P)
        {
            //P = new(80, 90);
            P.X++;
            P.Y++;
            Console.WriteLine($"P : {P.GetHashCode()}");
        }

        static void Main(string[] args)
        {
            #region Automatic Properties
            //Point P = new(10,10);
            ////P.X = 20; ///Immutable Point Class

            //Point P1 = new Point();
            //P1.X = 10;
            //P1.Y = 20;

            ///Object Initializer
            //Point P1 = new Point() { X = 10 , Y = 20 };
            //Console.WriteLine(P1);

            //P1.X = 50; ///not valid 

            //Console.WriteLine(P.X); 
            #endregion

            #region Access Modifiers
            //TypeOne O3 = new();

            //O3.K = 2;
            //O3.L = 5; ///not valid 
            #endregion

            #region Ctors
            //Point P1=new Point(10,15);
            //Point P2= new Point(20,25);

            ////Console.WriteLine($"P1 : {P1.GetHashCode()}");
            //Console.WriteLine($"P2 : {P2.GetHashCode()}");

            ////P2 = P1;
            ///////P2 , P1 same Object , same indetity , same State

            ////P2 = new Point(P1); ///Copy Ctor , only usage for copy ctor
            /////P2 new object with new idntity , same state
            ////Console.WriteLine($"P1 : {P1.GetHashCode()}");
            ////Console.WriteLine($"P2 : {P2.GetHashCode()}");

            //DemoFun(ref P2);

            //Console.WriteLine($"P2 : {P2}");
            //Console.WriteLine("After Fun Call");
            //Console.WriteLine($"P2 : {P2.GetHashCode()}");

            ////P1 = null; 
            #endregion

            #region Static Method , Ctor , Class
            ////ComplexNumber C1 = new();
            ////ComplexNumber C2 = new();

            ////C1.SetReal(10);
            ///////native code
            ///////SetReal (C1 , 10);
            /////

            //Console.WriteLine(Utility.Inch2Cm(10)); ///class Method , Static Method
            //Console.WriteLine(Utility.CircleArea(10));

            ////Utility U1 = new() { X = 1, Y = 2 };
            ////Utility U2 = new() { X = 3, Y = 4 };

            ////Console.WriteLine(Utility.counter); /// class attribute 

            ////Console.WriteLine(U1.Inch2Cm(10));
            ////Console.WriteLine(U2.Inch2Cm(10));

            //Console.WriteLine(Utility.Cm2Inch(40));

            //Console.WriteLine(Utility.CircleArea(10)); 
            #endregion

            #region Operator overloading
            //Point P1 = new() {  X = 10 , Y = 15 };
            //Point P2 = new() { X = 20, Y = 25 };
            //Point P3 = default;
            //Point P4 = default;

            ////P3 = P1 + P2;
            ////P3 = P1 + 5;

            ////P1 += P2;

            //P3 = ++P1;
            //P4 = P2++;


            //Console.WriteLine(P1);
            //Console.WriteLine(P2);
            //Console.WriteLine(P3);
            //Console.WriteLine(P4);

            ////int R = P4; ///implicit
            //int R = (int)P4;
            //Console.WriteLine(R);
            //string Str = (string)P4; ///explicit
            ////string Str2 = P4; ///Error
            //Console.WriteLine(Str);


            //Point3D P3D = new Point3D() {  XPos = 10 , YPos = 20 , ZPos= 30 };

            //P4 = (Point)P3D;
            //Console.WriteLine(P4); 
            #endregion

            GEngine O1;//= new GEngine(123456);
            GEngine O2;//= new GEngine(123456);

            O1 = GEngine.SingleTonObj;
            //GEngine.GetEngine();
            O2 = GEngine.SingleTonObj;
            //GEngine.GetEngine();

            Console.WriteLine($"O1 {O1.GetHashCode()} ");
            Console.WriteLine($"O2 {O2.GetHashCode()} ");

            O1.DoSomeGraphicsWork();

            Point P = null;

            //int Z = P.X;//unsafe 
            //int? Z = P?.X; (Point?.Int : int?) //Safe 
            //int Z = P?.X ??0;
        }
    }
}