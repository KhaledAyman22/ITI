//namespace D08_PII
//{

//    public delegate bool ConditionFuncDelDT(int i);

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

//        static List<int> FindMatchedCondition(List<int> Lst , ConditionFuncDelDT conFunPtr)
//        {
//            List<int> result = new List<int>();
//            for (int i = 0; i < Lst?.Count; i++)
//            {
//                if (conFunPtr?.Invoke(Lst[i])==true )
//                    result.Add(i);
//            }
//            return result;
//        }


//        static void Main(string[] args)
//        {
//            List<int> Lst = Enumerable.Range(0, 100).ToList();

//            List<int> Lst2;


//            ConditionFuncDelDT fPtr = new ConditionFuncDelDT(ChkFunctions.ChkOdd);
//            Lst2 = FindMatchedCondition(Lst, fPtr);

//            fPtr = ChkFunctions.ChkEven;
//            Lst2 = FindMatchedCondition(Lst, fPtr);

//            Lst2 = FindMatchedCondition(Lst, ChkFunctions.ChkDivBy7);

//            foreach (int item in Lst2)
//            {
//                Console.Write($"{item} , ");
//            }


//        }
//    }

//    class ChkFunctions
//    {
//        public static bool ChkOdd(int i) { return i % 2 == 1; }
//        public static bool ChkEven(int i) { return i % 2 == 0; }
//        public static bool ChkDivBy7(int i) { return i % 7 == 0; }

//    }
//}