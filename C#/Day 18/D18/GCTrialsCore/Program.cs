// See https://aka.ms/new-console-template for more information

using GCTrialsCore;
using ResourcePool;
using System.Buffers;

#region IDisposable 
//using TempFile temp = new();
//temp.DoSomeWork();
//temp.Dispose();
///

//TempFile? T = new TempFile();

//T.DoSomeWork();

//T = null;

//GC.Collect(2);

//GC.WaitForPendingFinalizers();

//Console.WriteLine("Hello");


#endregion

#region Array Pooling
//int[] NonpooledArray = new int[100];
//Console.WriteLine($"Non Pooled Array {NonpooledArray.GetHashCode()}");
//NonpooledArray = null;
/////next run for GC , GC will Collect Array Memory 

//int[] pooledArray = ArrayPool<int>.Shared.Rent(100);
//Console.WriteLine($"Pooled Array {pooledArray.GetHashCode()}");

//Console.WriteLine(pooledArray.Length); ///lenght 2^N

//for (int i = 0; i < 100; i++)
//	pooledArray[i] = i * 5;

/////return Array to Pool , GC will not Collect array Memory
//ArrayPool<int>.Shared.Return(pooledArray, true);
/////you shouldn't use ref pooledArray after returning it to the pool
//pooledArray = null;

//int[] Arr = ArrayPool<int>.Shared.Rent(128);
//Console.WriteLine(Arr.GetHashCode());


//ArrayPool<int>.Shared.Return(Arr);
#endregion

#region Resource Pooling

// Resource? R01 = RscPool.GetResource();
//    //new() { Name = "R01" };

//Console.WriteLine(	$"R01 {R01.GetHashCode()}");

//R01.UseResource();

//R01.Dispose();

////R01 = null;

//Console.WriteLine(	"Do Some Work");

//Console.WriteLine($"Pool Size {RscPool.PoolSize}");

//Resource R02 = RscPool.GetResource();
//    //new() { Name = "R02" };

//Console.WriteLine($"R02 {R02.GetHashCode()}");

//Resource R03 = RscPool.GetResource();
//Console.WriteLine($"R03 {R03.GetHashCode()}"); 
#endregion

///Tuple , Value Type , Mutable Value Type
//var Emp = new { ID = 1, Name = "Ahmed", Salary = 2000 };

/////Emp Object from Anonymous Type Class
//Console.WriteLine(Emp.GetType());

//var E1 = ("Ahmed", 2000);
//Console.WriteLine(  E1.GetType());
/////E1 ValueTuple Variable, Stack

//E1.Item1 = "Ali";
//E1.Item2 = 4000;

//Console.WriteLine( E1 );

//(string, int) E2 = ("Mona", 5000);

//E2 = GetEmployee(); ///return value Tuple from Function

//var E3 = (Name: "Mina", ID: 101);

//(string Name, int ID) E4 = ("Fady", 102);
//Console.WriteLine(E4.Name);


//IEnumerable<(string, int)> Temp01;

//Dictionary<(string,int),Uri > Temp02;


/////Type Erasure
//(string Name, int ID) T1 = (Name: "ABC", ID: 101);
//(string Branch, int EmpCount) T2 = (Branch: "ABC", EmpCount: 101);
/////T1 , T2 Same Data Type System.ValueTuple<string,int></string>

//if (T1==T2)
//    Console.WriteLine( "EQ" );
//else
//    Console.WriteLine("NEQ");

///Deconstructor Pattern
var E1 = ("Ahmed", 102); ///Value Tuple
(string Name , int ID) E2 = ("Ahmed", 102); //Value Tuple
Console.WriteLine(  E2);


(string Name, int ID) E3= E2 with { Name = "Ahmed Ali" };///new Value Tuple


(string Name, int ID) = E2;///DeConstructor E2
Console.WriteLine(  Name);
Console.WriteLine(  ID);

Manager M01 = new(501, "Mr.Manager", "IT");

///Deconstruct Object M01
(int MID, string MName, string MDept) = M01;

Console.WriteLine(  MID);
Console.WriteLine(  MName);
Console.WriteLine(  MDept);


/// <summary>
/// ///////The book of runtime 
/// https://github.com/dotnet/runtime/tree/main/docs/design/coreclr/botr
/// </summary>

//(string, int) GetEmployee() => ("Sally", 7000);

//class MyClass
//{
//    public MyFun()
//    {
//        return new { ID = 20, Name = "Taha" };
//    }
//}

class Point
{
    public int X { get; init; }
    public int Y { get; init; }

    //public Point(int _X , int _Y)
    //{
    //    X = _X;
    //    Y = _Y;
    //}

    public Point(int _X, int _Y) => (X, Y) = (_X, _Y);
    ///Deconstructor Pattern


}

class Manager
{
    public int ID { get; set; }
    public string Name { get; init; }
    public string Dept { get; init; }

    public Manager(int _ID , string _Name , string _Dept)
    {
        ID = _ID;
        Name = _Name;
        Dept = _Dept;
    }

    public void Deconstruct(out int id , out string name , out string dept)
    {
        id = ID;
        name = Name;
        dept = Dept;
    }


}