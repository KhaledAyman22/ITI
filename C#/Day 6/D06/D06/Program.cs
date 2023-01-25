namespace D06
{
    class Point3D : Point
    {
        public int Z { get; set; }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            #region Ex
            //Point P1, P2;
            //P1 = P2 = default;

            //if (P1?.X == P2?.X )
            //    Console.WriteLine("EQ");

            //if (P1 == null) P1 = new();

            //P1 ??= new();

            //int R = (P1?.X??0) + (P2?.X??0);

            #endregion

            #region Equals
            //Point P1 = new() {  X = 10 , Y = 20 };
            //Point P2 = new() { X = 15, Y = 15 };
            //Point P3 = new() { X = 10 , Y = 20 };
            //Point P4 = P1;

            /////P1 , P3 Same State , Diff Identity , 
            /////O1 , P4 Same State , Same Identity


            //if ( P1.Equals(P3))
            //    Console.WriteLine("P3 EQ P1");
            //else
            //    Console.WriteLine("P3 NEQ P1");


            //if (P1.Equals(P4))
            //    Console.WriteLine("P4 EQ P1");
            //else
            //    Console.WriteLine("P4 NEQ P1");

            //if (P1.Equals(P2))
            //    Console.WriteLine("P2 EQ P1");
            //else
            //    Console.WriteLine("P2 NEQ P1");


            //P3 = null;

            //if (P1.Equals(P3))
            //    Console.WriteLine("Null EQ P1");
            //else
            //    Console.WriteLine("NULL NEQ P1");


            //if (P1.Equals("P3"))
            //    Console.WriteLine("string EQ P1");
            //else
            //    Console.WriteLine("string NEQ P1");

            //Point3D P5 = new Point3D() {  X = 10 , Y =20  , Z = 30};


            //if (P1.Equals(P5))
            //    Console.WriteLine("P5 EQ P1");
            //else
            //    Console.WriteLine("P5 NEQ P1");


            #endregion

            #region Reference Equals
            //int X = 5;

            //Console.WriteLine(
            //    object.ReferenceEquals(X, X)
            //    ); 
            #endregion

            #region ISeries
            //SeriesByTwo S1 = new();

            //SeriesEngine.ProcessSeries(S1);

            //ISeries S02 = new FibSeries();
            ////object O02 = new FibSeries();
            ///////ref to Base = Derived Object

            //SeriesEngine.ProcessSeries(S02);

            #endregion

            #region Boxing in Interface
            //Employee E1 = new() { Id = 101, Name = "Aly", Salary = 4000 };

            ////E1.Promote();
            //E1.Promote();

            ////Console.WriteLine(E1);

            //IEmployee emp = E1;
            /////Iemp reference , System.Object 
            /////Boxing E1 into Heap in new Object 
            //emp.Promote();
            //Console.WriteLine(emp); ///6000
            //Console.WriteLine(E1);///5000 
            #endregion

            #region Inheritance Ex01
            //Parent P = new(10, 20, 30);
            //Console.WriteLine(P.Sum());

            //Derived D = new(40, 50, 60, 70);
            //Console.WriteLine(D.Sum()); ///Derived 
            //D.Z = 10;
            ////D.base.Sum(); //Not Valid 
            #endregion

            #region Virtual
            //TypeA BaseRef = new TypeA(1);
            //BaseRef.Show(); //Base
            //BaseRef.DynShow(); //Base

            //TypeB DerivedRef = new TypeB(2, 3);
            //DerivedRef.Show(); //Derived
            //DerivedRef.DynShow(); //Derived

            //TypeA BaseRef = new TypeB(4, 5);
            ///ref to Base = Derived object 
            //BaseRef.Show(); ///Base
            ///compiler will bind function call statically , early (@ Compilation time)
            ///based on Reference Type not Object Type
            //BaseRef.DynShow(); ///Derived
            ///CLR will Bind Function call Dynamically , Late (@ RunTime)
            ///based on Object Type not Ref Type


            //BaseRef = new TypeC();
            //BaseRef.DynShow(); ///TypeC

            //TypeB DRef = new TypeC();
            //DRef.DynShow(); ///TypeC

            //TypeD Dref = new();
            //Dref.DynShow(); ///TypeD

            //TypeA ARef = new TypeD();
            //ARef.DynShow();/// TypeC

            #endregion

            GeoShape G01;
            //G01 = new GeoShape();

        }



    }
    ///Dev01
    class SeriesEngine
    {
        public static void ProcessSeries (ISeries series)
        {
            for (int i=0; i < 10; i++)
            {
                Console.Write($"{series.Current} , ");
                series.MoveNext();
            }
            series.Reset();
            Console.WriteLine();
        }
    }
}