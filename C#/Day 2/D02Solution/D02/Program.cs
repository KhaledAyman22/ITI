using System;
using System.ComponentModel.DataAnnotations;

namespace D02
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Value Types
            //int X; ///int C# Keyowrd , 
            //       ///Allocate 4 Uninitialized Bytes

            //X = 7;

            //Int32 Y;

            //Y = X;

            //X++;

            //Console.WriteLine(X);
            //Console.WriteLine(Y); 
            #endregion

            #region Reference Types
            //Object O1;
            /////O1 Alias
            /////Zero Bytes have been allocated

            //O1 = new object();


            //object O2 = new(); 
            ////object O2 = new object();

            /////object : C# Keyword
            /////Object : BCL Class Name

            //Console.WriteLine(O1.GetHashCode());
            //Console.WriteLine(O2.GetHashCode());

            //O2 = O1;
            //Console.WriteLine("After O2 = O1");
            //Console.WriteLine(O1.GetHashCode());
            //Console.WriteLine(O2.GetHashCode()); 
            #endregion

            #region String Formatting
            //int X = 7, Y = 5;

            //Console.WriteLine("Hello World");
            //Console.WriteLine(X);

            //string Str = String.Format( "{0} + {1} = {2:X}",X , Y , X + Y );
            //Console.WriteLine(Str);
            //string.Empty;

            //Str = String.Format($"{X} + {Y} = {X+Y}");
            //Console.WriteLine(Str);

            //Str = $"{X} + {Y} = {X + Y}";
            //Console.WriteLine(Str);

            //Console.WriteLine($"{X} + {Y} = {X + Y}");

            //Str = "C:\\MyFolder\\MyFile";
            //Str = @"C:\MyFolder\MyFile";


            //Str = """
            //    <Element>
            //    This is my String
            //    and this Also 
            //    </Element>
            //    """;
            //Console.WriteLine(Str); 
            #endregion

            #region int.Parse
            //int X;
            //int Y;

            //X = int.Parse( Console.ReadLine());
            //Y = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine($"{X}+{Y}={X+Y}"); 
            #endregion

            //int X = 5;

            /////Not Valid
            ////if (X) ;
            ////if (1) ;
            ////if (0) ;
            ////if (X = 5) ;

            //if ( X ==5)
            //    Console.WriteLine("EQ 5");
            //else
            //    Console.WriteLine("NEQ");

            #region Block Statment
            // {
            //     X++;
            //     Console.WriteLine(X);
            // }

            ///// double i;

            // {
            //     int i = 0;
            //     ++i;
            //     Console.WriteLine(i);
            // }///end of i Scope

            // //Console.WriteLine(i); /// i Out of Scope


            // {
            //     string i = "Hello";
            //     Console.WriteLine(i.ToUpper());
            // } 
            #endregion

            //Console.WriteLine("Enter Month Number");
            //int M = int.Parse(Console.ReadLine());

            #region If\Else
            //if (M == 1)
            //    Console.WriteLine("Jan");
            //else if (M == 2)
            //    Console.WriteLine("Feb");
            //else if (M ==3)
            //    Console.WriteLine("Mar");
            //else if (M==4)
            //    Console.WriteLine("Apr");
            //else
            //    Console.WriteLine("NA");

            //Console.WriteLine("Rest of our Code"); 
            #endregion

            #region Switch Ex01
            //switch (M) 
            //{
            //    case 1:
            //        Console.WriteLine("Jan");
            //        break;
            //    case 2:
            //        Console.WriteLine("Feb");
            //        break;
            //    case 3:
            //        Console.WriteLine("Mar");
            //        break;
            //    default:
            //        Console.WriteLine("NA");
            //        break;
            //} 
            #endregion

            #region Switch Ex02
            //switch (M)
            //{
            //    case 1:
            //    case 3:
            //    case 5:
            //    case 7:
            //    case 8:
            //    case 10:
            //    case 12:
            //        Console.WriteLine("31");
            //        break;

            //    case 4:
            //    case 6:
            //    case 9:
            //    case 11:
            //        Console.WriteLine("30");
            //        break;

            //    case 2:
            //        Console.WriteLine("28");
            //        break;
            //    default:
            //        Console.WriteLine("NA");
            //        break;
            //} 
            #endregion

            #region Switch 03
            int Value = 3000;

            //switch (Value) 
            //{
            //    case 3000:
            //        Console.WriteLine("O3");
            //        Console.WriteLine("O2");
            //        Console.WriteLine("O1");
            //        break;
            //    case 2000:
            //        Console.WriteLine("O2");
            //        Console.WriteLine("O1");
            //        break;
            //    case 1000:
            //        Console.WriteLine("O1");
            //        break;
            //}

            //switch (Value)
            //{
            //    case 3000:
            //        Console.WriteLine("O3");
            //        goto case 2000;
            //    case 2000:
            //        Console.WriteLine("O2");
            //        goto case 1000;
            //    //default:
            //    case 1000:
            //        Console.WriteLine("O1");
            //        break;
            //} 
            #endregion

            #region Single Dim

            ////C Array Style
            ////int Arr[5];


            ////int[] Arr;///Array Reference 
            /////Zero Bytes allocated in Heap
            /////
            ////Arr = new int[5];
            /////Allocation , Initialzed 

            ////Arr = new int[5] { 7, 8, 9, 10,11 };
            ////Arr = new int[] { 7, 8, 9, 10, 11 };
            //int[] Arr1 =  { 7, 8, 9, 10, 11,12 , 13 };

            //Console.WriteLine($"Array Lengh :{Arr1.Length}");


            //int[] Arr2 = { 1, 2, 3 };

            //Console.WriteLine($"Arr1 {Arr1.GetHashCode()}");
            //Console.WriteLine($"Arr2 {Arr2.GetHashCode()}");


            ////Arr2 = Arr1;
            /////Arr2 , Arr1 same object same identity

            //Console.WriteLine("Arr 2 = Arr1.Clone()");
            //Arr2 = (int[]) Arr1.Clone();
            /////Derived Ref = Base Object , unsafe 
            /////Arr2 New Object , new Identity , same state as Arr1


            //Console.WriteLine($"Arr1 {Arr1.GetHashCode()}");
            //Console.WriteLine($"Arr2 {Arr2.GetHashCode()}");

            //Arr2[0] = 777;

            //for (int i = 0; i < Arr1.Length; i++)
            //    Console.WriteLine(Arr1[i]);

            //if (7 < Arr1.Length)
            //    Arr1[7] = 20; ///Exceed Upper Bound
            //else
            //    Console.WriteLine("Exceeding Upperbound"); 
            #endregion

            #region 2 Dim
            //int[] Arr = { 1, 2, 3, 4, 5 };

            //Console.WriteLine(Arr[0]);

            ////int[,] Marks = new int[3, 5];
            //int[,] Marks = new int[3, 5] { { 1, 2, 3, 4, 5 }, { 4, 5, 6, 7, 8 }, { 9, 10, 11, 12, 13 } };

            //Console.WriteLine(Marks.Length);
            //Console.WriteLine(Marks.Rank);

            //for (int i = 0; i < Marks.GetLength(0); i++)
            //    for (int j = 0; j < Marks.GetLength(1); j++)
            //        Marks[i, j] = (i + 5) * j; 
            #endregion

            #region Jagged Array
            //int[][] JArr = new int[3][];

            //JArr[0] = new int[3];
            //JArr[1] = new int[7];
            //JArr[2] = new int[5];

            //Console.WriteLine(JArr[0][1]); 
            #endregion


            ///Index , Range
            char[] Vowls = { 'a', 'o', 'i', 'e', 'u' };

            //Char Ch = Vowls[0];

            //Console.WriteLine(Ch);

            //Ch = Vowls[4];
            //Console.WriteLine(Ch);

            /////^0 = Lengh
            /////^1 = UpperBound /// Lengh-1
            ////Ch = Vowls[^0];///Indexoutofrangeexception
            /////Last Cell
            //Ch = Vowls[^1];
            //Ch = Vowls[^3];

            //Index LastIndex = ^1;
            //Ch= Vowls[LastIndex];
            //Console.WriteLine(Ch);


            ///Slicing
            char[] Arr = Vowls[0..2]; //[included..excluded]
            Console.WriteLine(Vowls.GetHashCode());
            Console.WriteLine(Arr.GetHashCode());


            Arr = Vowls[..2];
            Arr = Vowls[2..];
            Arr = Vowls[2..3];
            Arr = Vowls[1..^2];

            Range MyRange = ^4..^2;
            Arr = Vowls[MyRange];

            for (int i = 0; i < Arr.Length; i++) { Console.WriteLine(Arr[i]); }


            foreach (char item in Arr) ///foreach iteration variable : Arr[i]
            {
                Console.WriteLine(item);
                //item = 'a';/// item read only
            }

        }
    }
}