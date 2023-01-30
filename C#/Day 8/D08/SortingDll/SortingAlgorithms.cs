//namespace SortingDll
//{
//    /// <summary>
//    /// Step 0:
//    /// Delegate DT Declaration
//    /// </summary>
//    public delegate bool CompFuncDelDT(int L, int R);

//    public class SortingAlgorithms
//    {
//        public static void BSort(int[] Arr , CompFuncDelDT CompFuncPtr )
//        {
//            bool Sorted = false;

//            for (int i = 0; (i < Arr?.Length) && (!Sorted); i++)
//            {
//                Sorted = true;
//                for (int j = 0; j < Arr.Length - i - 1; j++)
//                    if (CompFuncPtr?.Invoke(Arr[j], Arr[j + 1])==true) ///safe
//                    {
//                        SWAP(ref Arr[j], ref Arr[j + 1]);
//                        Sorted = false;
//                    }
//            }
//        }


//        public static void BSort (int[] Arr)
//        {
//            bool Sorted = false;

//            for ( int i=0; (i<Arr?.Length)&&(!Sorted); i++ ) 
//            {
//                Sorted= true;
//                for ( int j =0; j < Arr.Length - i - 1; j++)
//                    if (CompFuncs.ChkGrt(Arr[j] , Arr[j+1]))
//                    {
//                        SWAP(ref Arr[j], ref Arr[j + 1]);
//                        Sorted = false;
//                    }
//            }
//        }

//        public static void SWAP ( ref int X , ref int Y )
//        {
//            int Temp = X;
//            X = Y;
//            Y = Temp;
//        }

//    }

//    public class CompFuncs
//    {
//        public static bool ChkGrt (int L , int R) { return L > R; }
//        public static bool ChkLwr(int L , int R) { return L < R; }
//    }
//}