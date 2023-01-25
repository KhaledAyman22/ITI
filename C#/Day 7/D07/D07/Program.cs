global using System.ComponentModel;
global using System.Collections.Generic;
global using System;

namespace D07
{
    internal class Program
    {

        #region non Generic SWAP
        //public static void SWAP (ref int x , ref int y)
        //{
        //    int Temp = x;
        //    x = y;
        //    y = Temp;
        //}

        //public static void SWAP(ref double x, ref double y)
        //{
        //    double Temp = x;
        //    x = y;
        //    y = Temp;
        //}

        //public static void SWAP(ref string x, ref string y)
        //{
        //    string Temp = x;
        //    x = y;
        //    y = Temp;
        //} 
        #endregion

        public static void SWAP<T>(ref T x, ref T y)
        {
            T Temp = x;
            x = y;
            y = Temp;
        }

        public static TResult DemoFun<T1,T2,TResult> ( T1 X , T2 Y)
        {
            TResult x = default;
            return x;
        }

        //public static int SumList ( ArrayList lst)
        //{
        //    int Sum = 0; 
        //    for ( int i=0; i < lst.Count; i++ ) 
        //    {
        //        Sum += (int)lst[i]; ///UnBoxing , UnSafe
        //    }
        //    return Sum;
        //}

        public static int SumList (List<int> lst)
        {
            int Sum = 0;
            for ( int i=0; i < lst?.Count; i++)
                Sum += lst[i];///Safe 
            return Sum;

        }

        static void Main(string[] args)
        {
            #region IComparable , IComparer
            int[] Arr = { 5, 9, 4, 8, 3, 1, 6, 2, 7 };

            //Array.Sort(Arr);

            //foreach (int i in Arr) { Console.WriteLine(i); }

            Point[] pArr = { new() { X = 15, Y = 10 }, new() { X = 5, Y = 20 }, new() { X = 15, Y = 5 } };

            //Array.Sort(pArr); ///default Comparer :: IComparable Implementation
            ///// if (pArr[i].CompareTo(Arr[i+1])

            //Array.Sort(pArr, new PointComparer());
            ///// pointComparer.Compare (pArr[i],pArr[i+1])

            //foreach (Point item in pArr)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Generic Method
            //double dd = DemoFun<float, int, double>(5.0f, 5);

            //int A = 10, B = 5;

            //SWAP(ref A, ref B); ///Type inference , Jit Compiler , Detect T Type from Call
            //SWAP<int>(ref A, ref B);


            //Console.WriteLine($"A = {A}");
            //Console.WriteLine($"B = {B}");

            //Double D1 = 1.2345, D2 = 1234.5;
            //SWAP(ref D1, ref D2);

            //Console.WriteLine($"D1 = {D1}");
            //Console.WriteLine($"D2 = {D2}");

            //string Str1 = "ABC", Str2 = "XYZ";
            //SWAP(ref Str1, ref Str2);

            //Console.WriteLine($"Str1 : {Str1}");
            //Console.WriteLine($"Str2 : {Str2}");

            //Point P1 = new() { X = 5, Y = 5 };
            //Point P2 = new() { X = 20, Y = 20 };

            //SWAP(ref P1, ref P2);

            //Console.WriteLine($"P1 : {P1}");
            //Console.WriteLine($"P2 : {P2}"); 
            #endregion

            #region Generic Class
            //Helper<int> intHelper = new Helper<int>();
            //Console.WriteLine(intHelper.SearchArray(Arr , 9));

            //char[] arr = { 'a', 'b', 'c', 'd' };
            //Helper<char> charHelper = new Helper<char>();
            //Console.WriteLine(charHelper.SearchArray(arr , 'c'));

            //string[] sArr = { "Sally", "Ali", "Mona", "Sara", "Basem" };
            //Helper<string>.BSort(sArr);

            //foreach (var item in sArr)
            //{
            //    Console.WriteLine(item);
            //}

            //Helper<Point>.BSort(pArr); 
            #endregion

            #region non Generic Collection
            //ArrayList aLst = new();

            //aLst.Add(1);
            //aLst.Add(2);//Boxing
            //aLst.Add("3");///Compiler can't Enforce Type Safetly

            //aLst.AddRange(new int[] { 4, 5, 6, 7 });

            //Console.WriteLine(aLst[2]);

            //Console.WriteLine(SumList(aLst)); 
            #endregion

            #region List
            //List<int> aLst = new();
            //Console.WriteLine($"Element Numbers {aLst.Count} , Size in Memory {aLst.Capacity}");

            //aLst.Add(1);
            //Console.WriteLine($"Element Numbers {aLst.Count} , Size in Memory {aLst.Capacity}");
            //aLst.Add(2);
            ////aLst.Add("3");
            //aLst.Add(3);
            /////Type Safety @ Compilation
            //aLst.Add(4);
            //Console.WriteLine($"Element Numbers (count) {aLst.Count} , Size in Memory(Capacity) {aLst.Capacity}");
            //aLst.Add(5);
            //Console.WriteLine($"Element Numbers (count) {aLst.Count} , Size in Memory(Capacity) {aLst.Capacity}");


            //aLst.AddRange(new int[] { 6, 7 , 8 });
            //Console.WriteLine($"Element Numbers (count) {aLst.Count} , Size in Memory(Capacity) {aLst.Capacity}");

            //aLst.Add(9);
            //Console.WriteLine($"Element Numbers (count) {aLst.Count} , Size in Memory(Capacity) {aLst.Capacity}");

            //aLst.TrimExcess();
            //Console.WriteLine($"Element Numbers (count) {aLst.Count} , Size in Memory(Capacity) {aLst.Capacity}");

            //aLst.Add(10);
            //Console.WriteLine($"Element Numbers (count) {aLst.Count} , Size in Memory(Capacity) {aLst.Capacity}");

            ////aLst.
            //aLst[0] = 11; ///Update 
            #endregion

            Dictionary<string, long> PhoneBook = new();
            PhoneBook.Add("ABC", 123);
            PhoneBook.Add("XYZ", 456);
            PhoneBook.Add("KLM", 789);

            //PhoneBook.Add("XYZ", 654); ///Exception
            if ( PhoneBook.TryAdd("XYZ" , 654))
                Console.WriteLine("Added");
            else
                Console.WriteLine("Already Existing");


            PhoneBook["XYZ"] = 654; ///Update
            PhoneBook["DEF"] = 777; ///Add

            Console.WriteLine(PhoneBook["XYZ"]);

            foreach( KeyValuePair<string,long> item in PhoneBook)
            {
                Console.WriteLine($"{item.Key} ::: {item.Value}");
            }

            //Console.WriteLine(PhoneBook["xyz"]); ///unsafe

            if ( PhoneBook.TryGetValue("xyz",out long PN))
                Console.WriteLine(PN);
            else
                Console.WriteLine("NA");



        }
    }
}