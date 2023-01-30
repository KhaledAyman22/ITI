//namespace D08_PII
//{
//    internal class Program
//    {

//        static List<int> FindOddNumber (List<int> Lst)
//        {
//            List<int> result = new List<int>();
//            for ( int i=0; i < Lst?.Count; i++ ) 
//            {
//                if (Lst[i] %2 == 1)
//                    result.Add(Lst[i]);
//            }
//            return result;
//        }

//        static List<int> FindEvenNumber(List<int> Lst)
//        {
//            List<int> result = new List<int>();
//            for (int i = 0; i < Lst?.Count; i++)
//            {
//                if (Lst[i] % 2 == 0)
//                    result.Add(Lst[i]);
//            }
//            return result;
//        }

//        static List<int> FindDiv7(List<int> Lst)
//        {
//            List<int> result = new List<int>();
//            for (int i = 0; i < Lst?.Count; i++)
//            {
//                if (Lst[i] % 7 == 0)
//                    result.Add(Lst[i]);
//            }
//            return result;
//        }



//        static void Main(string[] args)
//        {
//            List<int> Lst = Enumerable.Range(0,100).ToList();

//            List<int> Lst2;


//            Lst2 = FindOddNumber (Lst);

//            Lst2 = FindEvenNumber(Lst);

//            Lst2 = FindDiv7(Lst);


//            foreach (int item in Lst2)
//            {
//                Console.Write($"{item} , ");
//            }


//        }
//    }
//}