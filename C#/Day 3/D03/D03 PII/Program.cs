using System.Diagnostics;
//using Common;

#region Struct
////Console.WriteLine("Hello");
////Trace.WriteLine("Hello Output Window");

////TypeA AVar;
////AVar.Y = 2;
//////AVar.Z = 3; ///outised Project (Assemby file)

//int X; ///allocation 4 bytes , uninitialized , no call for int ctor

//int Y = new int(); /// Allocation 4 byte use paramterless ctor for initialization with 0

////Console.WriteLine(X); ///Compilation Error
//Console.WriteLine(Y); //valid

//Point P1; ///no Call to Any Ctor , UNINitialzed
/////Allocation 8 bytes in Stack , Uninitialized 

////P1.Print(); ///not Valid

////P1.X = 10;
////P1.Y = 10;

//Point P2 = new Point(10, 15);
////8 Bytes in Stack , select Ctor(int,int) for Initialization
////new used with value type just for selecting Ctor
//P2.Print();

//Point P3 = new Point(15);
//P3.Print();

//Point P4 = new Point();/// for every Struct , Compiler will generate defualt paramterless ctor , 
/////intializing all members to default values
//P4.Print();

//Console.WriteLine(P3);
//Console.WriteLine(P4.ToString()); 
#endregion

#region Ex01 Enum
//Grades MyG; ///allocated in Stack 

//MyG = Grades.A; /// initialization

//switch (MyG)
//{
//    case Grades.A:
//        break;
//    case Grades.B:
//        break;
//    case Grades.C:
//        break;
//    case Grades.D:
//        break;
//    case Grades.F:
//        break;
//    default:
//        break;
//}

//if ( MyG == Grades.A)
//    Console.WriteLine("(Y)");
//else if (MyG == Grades.F)
//    Console.WriteLine(":(");

//Console.WriteLine(MyG); 
#endregion


#region Ex02 Enum
//Branches B = Branches.Mansoura;

//B = Branches.Qena;

//B = (Branches)15;


//B = (Branches)153;

//Console.WriteLine(B); 
#endregion

Permission MyP = Permission.Read;

MyP ^= Permission.Execute;
MyP ^= Permission.Write;
MyP ^= Permission.Delete;


//MyP = (Permission)0x0F;

Console.WriteLine(MyP);
MyP ^= Permission.Execute;

//MyP ^= Permission.Delete;
Console.WriteLine(MyP);



enum Grades
{
    A,B, C, D, F,
}

enum Branches:byte
{
    SV=101 , Alex =152, Mansoura , Sohag =226, Qena , Aswan
}

[Flags]
enum Permission
{
    Read = 8 , Write = 0x04 , Execute = 0b_0000_0010 ,Delete = 0x01 ,SuperUser = 0b_0000_1100 , Admin = 0x0F
}

struct Point
{
     int X; 
     int Y;

    ///Userdefined Ctor
    public Point(int _X =5, int _Y=5)
    {
      //  X = _X; ///C#1.X ... C#10 , Not Valid 
      ///C# 11 , X will be intitialized to default value
        Y = _Y;
    }

    public Point(int n)
    {
        X = Y = n;
    }

    ///Userdefined Parameterless Ctor , Valid only in C#11
    public Point()
    {
        X = Y = -1;
    }

    public override string ToString()
    {
        return $"({X},{Y})";
    }

    public void Print()
    {
        Console.WriteLine($"({X},{Y})");
    }
}