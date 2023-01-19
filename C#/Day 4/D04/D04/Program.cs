
using System.Diagnostics;

#region Value Type
//int A = 7, B = 3;

////Demo.SWAP(A, B);///Pass by Value
//Demo.SWAP(ref A,ref B);///Pass by Reference

//Console.WriteLine($"A = {A}");
//Console.WriteLine($"B = {B}"); 
#endregion

#region Reference Type
//int[] Arr = { 1, 2, 3, 4, 5 };

//Console.WriteLine(
//    Demo.SumArray(Arr)
//    );

//Console.WriteLine(Arr[0]); 
#endregion

#region Named , Default Input Paramteters
//int X;
//Console.WriteLine("Enter New Value");
//X = int.Parse(Console.ReadLine());
//PrintLine(8 , ":_-_:");

//PrintLine();
//PrintLine(10);
//PrintLine(Pattern:"^"); ///count:5 

//int Y = ++X;
//Console.WriteLine(X);
//PrintLine(Pattern:"=" , Count:5); ///Named Input Parameters
//Console.WriteLine(Y); 
#endregion

#region Print Line

//static void PrintLine(int Count=5 , String Pattern="*")
//{
//    //FunOne();
//    int i;
//    for (i =0; i < Count; i++)
//        Console.Write(Pattern);
//    Console.WriteLine();
//}

//static void DemFun ( int x , int y =2 , int z = 3) { }
//static void DemFun2(int x, int y , int z = 3) { }

///notValid
//static void DemFun3(int x=1, int y, int z = 3) { }


//static int FunOne()
//{
//    FunTwo(5);
//    return 5;
//}

//static void FunTwo(int Y)
//{
//    Console.WriteLine(Y);

//    //int Z = new();

//    //Console.WriteLine(Y / Z);

//    //StackTrace stackTrace = new();

//    //foreach (StackFrame sFrame in stackTrace.GetFrames())
//    //{
//    //    Console.WriteLine(sFrame.GetMethod().Name);
//    //}



//} 
#endregion

//int A = 7, B = 3 , SumResult , MulResult;

////Demo.SumMul(A , B , ref SumResult , ref MulResult); ///pass by ref , Variable must be initialzed
//Demo.SumMul(A, B, out SumResult, out MulResult); ///pass by out , Variable can be uninitialized

//int A = 7, B = 3;

//Demo.SumMul(A, B ,out int SumResult, out int MulResult);


//Console.WriteLine($"Sum = {SumResult}");
//Console.WriteLine($"Mul = {MulResult}");

//int A = 7, B = 3;

//Demo.SumMul(A, B, out int SumResult, out _); ///_ : Discard


//Console.WriteLine($"Sum = {SumResult}");

///Variable lenght input parameters 

Demo.SumArray(new int[] { 1, 2, 3, 4});

Console.WriteLine(
    $"{ Demo.SumArrayVar("Arr1", 1, 2, 3)}  ,   { Demo.SumArrayVar("Arr2" , 1, 2, 3,4,5)}"
    );


class Demo
{
    ///Pass By Value to Function : Read Only
    ///Pass By Ref to Function : Read , Write 
    ///Pass By out To Function : Write First
    public static void SumMul(int X , int Y , out int S ,out int M)
    {
        S= X + Y;
        M= X * Y;
    }

    ///Reference Type pass by Ref
    public static int SumArray(ref int[] MyArr)
    {
        throw new NotImplementedException();
    }
    ///Variable lenght input parameteres
    public static int SumArrayVar(string Title , params int[] MyArr)
    {
        int Sum = 0;
        for (int i = 0; i < MyArr?.Length; i++)
        {
            Sum += MyArr[i];
        }
        // MyArr[0] = 77;
        return Sum;
    }



    ///Reference Type pass by Value
    public static int SumArray(int[] MyArr)
    {
        int Sum = 0;
        for ( int i=0; i < MyArr?.Length; i++ ) 
        {
            Sum += MyArr[i];
        }
       // MyArr[0] = 77;
        return Sum;
    }

    ///Value Type , pass By Reference
    public static void SWAP(ref int X,ref int Y)
    {
        int Temp = X;
        X = Y;
        Y = Temp;
    }

    ///Value Type, Pass By value
    //public static void SWAP (int X , int Y)
    //{
    //    int Temp = X;
    //    X = Y;
    //    Y = Temp;
    //}
}