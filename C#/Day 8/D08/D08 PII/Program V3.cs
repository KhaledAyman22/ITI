//namespace D08_PII
//{
//    class MyType { }
//    class MyType<T> { }
//    class MyType<T1,T2> { }


//    ///non Generic Delegate
//    //public delegate bool ConditionFuncDelDT(int i);

//    ///Generic Delegates
//    public delegate bool ConditionFuncDelDT<T>(T i);



//    internal class Program
//    {

//        #region V1.0
//        //static List<int> FindOddNumber(List<int> Lst)
//        //{
//        //    List<int> result = new List<int>();
//        //    for (int i = 0; i < Lst?.Count; i++)
//        //    {
//        //        if (Lst[i] % 2 == 1)
//        //            result.Add(Lst[i]);
//        //    }
//        //    return result;
//        //}

//        //static List<int> FindEvenNumber(List<int> Lst)
//        //{
//        //    List<int> result = new List<int>();
//        //    for (int i = 0; i < Lst?.Count; i++)
//        //    {
//        //        if (Lst[i] % 2 == 0)
//        //            result.Add(Lst[i]);
//        //    }
//        //    return result;
//        //}

//        //static List<int> FindDiv7(List<int> Lst)
//        //{
//        //    List<int> result = new List<int>();
//        //    for (int i = 0; i < Lst?.Count; i++)
//        //    {
//        //        if (Lst[i] % 7 == 0)
//        //            result.Add(Lst[i]);
//        //    }
//        //    return result;
//        //} 
//        #endregion

//        #region V2.0
//        //static List<int> FindMatchedCondition(List<int> Lst, ConditionFuncDelDT conFunPtr)
//        //{
//        //    List<int> result = new List<int>();
//        //    for (int i = 0; i < Lst?.Count; i++)
//        //    {
//        //        if (conFunPtr?.Invoke(Lst[i]) == true)
//        //            result.Add(Lst[i]);
//        //    }
//        //    return result;
//        //} 
//        #endregion

//        static List<T> FindMatchedCondition<T>(List<T> Lst, ConditionFuncDelDT<T> conFunPtr)
//        {
//            List<T> result = new();
//            for (int i = 0; i < Lst?.Count; i++)
//            {
//                if (conFunPtr?.Invoke(Lst[i]) == true)
//                    result.Add(Lst[i]);
//            }
//            return result;
//        }

//        static void Main(string[] args)
//        {
//            List<int> Lst = Enumerable.Range(0, 100).ToList();

//            List<int> Lst2;


//            ConditionFuncDelDT<int> fPtr = new ConditionFuncDelDT<int>(ChkFunctions.ChkOdd);
//            Lst2 = FindMatchedCondition(Lst, fPtr);

//            fPtr = ChkFunctions.ChkEven;
//            Lst2 = FindMatchedCondition(Lst, fPtr);

//            Lst2 = FindMatchedCondition(Lst, ChkFunctions.ChkDivBy7);

//            foreach (int item in Lst2)
//            {
//                Console.Write($"{item} , ");
//            }


//            List<string> NameList = new() { "Ahmed", "Sally", "Salah", "Mena", "Nader", "Mai", "Ali" };

//            ChkFunctions O1 = new() { Ch = 'a' };

//            ConditionFuncDelDT<string> sfPtr = O1.ChkChar;

//            foreach (string item in FindMatchedCondition<string>(NameList , sfPtr))
//            {
//                Console.WriteLine(item);
//            }


//        }
//    }

//    class ChkFunctions
//    {
//        public char Ch { get; set; }

//        internal  bool ChkChar (string Str)
//        {
//            return Str.Contains(Ch);
//        }

//        public static bool ChkOdd(int i) { return i % 2 == 1; }
//        public static bool ChkEven(int i) { return i % 2 == 0; }
//        public static bool ChkDivBy7(int i) { return i % 7 == 0; }

//    }
//}