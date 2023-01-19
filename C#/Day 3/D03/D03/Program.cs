#region Misc
//string Month = Console.ReadLine();

//switch(Month)
//{
//    case "1":
//        Console.WriteLine("Jan");
//        break;
//    case "2":
//        Console.WriteLine("Feb");
//        break;
//    case "3":
//        Console.WriteLine("Mar");
//        break;
//}

////long X = 5_000_000_000;
//float f = 13.5f;
//decimal Salary = 1000.5m;

//Console.WriteLine(7.0 / 2); 
#endregion

#region Type Casting between Built in Value Types

//Int32 X = 50;  ///int
//Int64 Y = 5000; ///long


/////Implicit Casting
/////Safe Casting can be implicit casting
/////no loss of Data
////Y = X;


//Y = Int64.MaxValue;

/////UnSafe Casting
/////Must be explicit Casting
//X = (int)Y;
/////default for CLR , will not Throw Overflowexception if overflow happens

/////Enforcing OverflowException
//checked
//{
//    X = (int)Y;
//}

//Console.WriteLine($"X = {X}");
//Console.WriteLine($"Y = {Y}");


#endregion


#region Boxing , UnBoxing
///Any ValutType & System.Object

//int X = 50;

//object O1 = new();

/////Boxing , Safe , Implicit 
//O1 = X;
/////Object = Int32
/////Base Ref = Derived

//O1 = "Hello";


//int Y;

//Y = (int)O1;
/////Derived = Base
/////unSafe
/////Explicit 
/////UnBoxing


//Console.WriteLine(Y);

#endregion


int X = 770;

//X = null;///not valid


///nullable value type
int? Y = 500; /// Nullable<int> Y = 500;
Y = null;

///Safe , Implicit
//Y = X;

///unsafe , explicit 
//X =(int) Y; /// non Protective Programming

//if (Y != null)
//    X = (int)Y;
//else
//    X = -1;

//if (Y.HasValue)
//    X = Y.Value;
//else
//    X = -1;


//X = (Y != null) ? (int)Y : -1;

//X = Y.HasValue? Y.Value : -1;

//X = Y ?? -1;


Console.WriteLine($"X = {X}");
Console.WriteLine($"Y = {Y}");



int? Z = 55;

X = Z.Value; ///valid , not Safe : Z.value :: int

//X = Z?.Value; ///Safe , not valid :: Z?.value ::int?

X = Z??-1;





Employee E = default; ///null
    //= new(); E.Name = "Test";

//E = new Employee();
//E.Name = "Ahmed";

PrintName(E);


int[] MyArr = { 1, 2, 3, 4, 5 };

Console.WriteLine(SumArray(MyArr));

int[] Arr2 = null;

Console.WriteLine(SumArray(Arr2));

static int SumArray(int[] Arr)
{
    int Sum = 0;
    for (int i = 0; i < Arr?.Length; i++)
        Sum += Arr[i];
    return Sum;
}



static void PrintName ( Employee E)
{
    //if ((E != null)&&(E.Dept != null))
        Console.WriteLine($"{E?.Name?.Length??-1} {E?.Dept?.Name??"NA"}");
}


class Employee
{
    public int Id;
    public string Name;
    public Dept Dept;
}

class Dept
{
    public string Name;
}