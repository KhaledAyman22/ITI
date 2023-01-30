using SortingDll;

namespace D08
{
    ///<summary>
    /// Step Zero : Pointer to Function (Delegate )Declaration : int*
    /// Delegate Data Type Declaration 
    /// use keyword delegate 
    /// </summary>
    public delegate int DemoDelDT(string S);
    /// <summary>
    /// creation of new class DemoDelDT : MulticastDelegate
    /// </summary>

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] Arr = { 5, 3, 4, -8, 7, -2, 6, 1 };

            //SortingAlgorithms.BSort(Arr);

            #region non Generic
            /////Step 1 , 2 
            //CompFuncDelDT fPtr = new CompFuncDelDT(CompFuncs.ChkLwr);

            //SortingAlgorithms.BSort(Arr, fPtr);

            ////fPtr = new CompFuncDelDT(ModernCompFuncs.ChkABSLwr);
            ////fPtr = ModernCompFuncs.ChkABSLwr;
            ////SortingAlgorithms.BSort(Arr, fPtr); 


            //SortingAlgorithms.BSort(Arr, ModernCompFuncs.ChkABSLwr);

            ////SortingAlgorithms.BSort(Arr, DemoFunctions.GetLenght);///Compiler Error

            //SortingAlgorithms.BSort(Arr, null); 
            #endregion

            #region User Defined Delegates
            /////Step 1 , 2 
            //CompFuncDelDT< int , int,bool> fPtr = new CompFuncDelDT< int, int,bool>(CompFuncs.ChkLwr);

            //SortingAlgorithms<int>.BSort(Arr, fPtr);

            ////fPtr = new CompFuncDelDT(ModernCompFuncs.ChkABSLwr);
            //fPtr = ModernCompFuncs.ChkABSLwr;
            //SortingAlgorithms<int>.BSort(Arr, fPtr);


            //SortingAlgorithms<int>.BSort(Arr, ModernCompFuncs.ChkABSLwr);

            ////SortingAlgorithms.BSort(Arr, DemoFunctions.GetLenght);///Compiler Error

            //SortingAlgorithms<int>.BSort(Arr, null);

            //foreach (int i in Arr) { Console.WriteLine(i); }

            //string[] NameList = { "Ahmed", "Sally", "Salah", "Mena", "Nader", "Mai", "Ali" };

            //CompFuncDelDT<string, string , bool> sfPtr = ModernCompFuncs.ChkLenght;

            //SortingAlgorithms<string>.BSort(NameList , sfPtr);

            //foreach (string item in NameList)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            ///Step 1 , 2 
            //Func<int, int, bool> fPtr = new Func<int, int, bool>(CompFuncs.ChkLwr);

            //SortingAlgorithms<int>.BSort(Arr, fPtr);

            ////fPtr = new CompFuncDelDT(ModernCompFuncs.ChkABSLwr);
            //fPtr = ModernCompFuncs.ChkABSLwr;
            //SortingAlgorithms<int>.BSort(Arr, fPtr);


            //SortingAlgorithms<int>.BSort(Arr, ModernCompFuncs.ChkABSLwr);

            ////SortingAlgorithms.BSort(Arr, DemoFunctions.GetLenght);///Compiler Error

            //SortingAlgorithms<int>.BSort(Arr, null);

            ///Anonymous Method
            //Func<int,int,bool> fPtr = delegate (int L, int R) { return Math.Abs(L) > Math.Abs(R); };
            
            //SortingAlgorithms<int>.BSort(Arr, fPtr);

            SortingAlgorithms<int>.BSort(Arr , (L,R)=> Math.Abs(L) > Math.Abs(R));


            //foreach (int i in Arr) { Console.WriteLine(i); }

            //string[] NameList = { "Ahmed", "Sally", "Salah", "Mena", "Nader", "Mai", "Ali" };

            //Func<string, string, bool> sfPtr = ModernCompFuncs.ChkLenght;

            //SortingAlgorithms<string>.BSort(NameList, sfPtr);

            //foreach (string item in NameList)
            //{
            //    Console.WriteLine(item);
            //}

            #region Delegate Ex01

            /////Step 1 : Pointer to Function Declaration
            /////Declare Object from Delegate class
            //DemoDelDT fPtr;

            /////Step 2 : Pointer to Function Initialization
            /////Assgin Function address to Pointer Object
            /////Detailed version
            //fPtr = new DemoDelDT(DemoFunctions.GetLenght);

            /////Step 3: Using Pointer Call(invoke) Function
            /////Shorthand version , not Safe
            //int R = fPtr("Hello");

            //Console.WriteLine(R);

            ////fPtr = new DemoDelDT(DemoFunctions.GetUpperCount);
            /////Shorthand version of Delegate Object Initialized 
            //fPtr = DemoFunctions.GetUpperCount;

            /////Safe
            ////if (fPtr != null)
            ////    fPtr("AbCdEfGh");///unsafe 

            /////Call Function using Function Pointer
            /////Detailed , safe
            //R= fPtr?.Invoke("AbCdEf")??0;

            //Console.WriteLine(R);

            //DemoFunctions O1 = new DemoFunctions { Ch = 'a' };
            //DemoFunctions O2 = new DemoFunctions { Ch = 'Z' };

            //fPtr = new DemoDelDT(O2.GetCharCount);

            //R = fPtr?.Invoke("ZzZz") ?? -1;

            //Console.WriteLine(R);

            ////fPtr = new DemoDelDT(DemoFunctions.ChkNull);

            ////fPtr = new DemoDelDT(DemoFunctions.SumLength); 
            #endregion

        }
    }
    class ModernCompFuncs
    {
        public static bool ChkLenght (string L , string R)
        {
            return L.Length > R.Length;
        }

        public static bool ChkABSLwr ( int L , int R)
        {
            return Math.Abs(L) < Math.Abs(R);
        }
    }


    class DemoFunctions
    {
        public static int GetLenght (string Str) { return Str?.Length ?? -1; }

        public char Ch { get; set; }

        public int GetCharCount (String Str)
        {
            int Counter = 0;
            foreach (char c in Str) 
             if(c == this.Ch)
                  Counter++;
            return Counter;
        }

        public static int GetUpperCount (string Str)
        {
            int Counter = 0;
            foreach (char c in Str)
                if (char.IsUpper(c))
                    Counter++;
            return Counter;
        }

        public static bool ChkNull (string Str) { return Str == null; }

        public static int SumLength ( string L , string R) {  return L.Length + R.Length; }
    }
}