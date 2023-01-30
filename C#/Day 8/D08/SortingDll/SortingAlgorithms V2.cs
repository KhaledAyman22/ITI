namespace SortingDll
{
    /// <summary>
    /// Step 0:
    /// Delegate DT Declaration
    /// </summary>
    //public delegate bool CompFuncDelDT(int L, int R);

    //public delegate bool CompFuncDelDT<in T>(T L, T R);

    //public delegate TResult CompFuncDelDT< in T1, in T2, out TResult>(T1 L, T2 R);
    /// in BCL (Built in)
    /// 
    /// public delegate TResult Func<out TResult >( );
    /// public delegate TResult Func<out TResult, in T1>(T1 L);
    /// public delegate TResult Func<out TResult, in T1, in T2>(T1 L, T2 R);




    public class SortingAlgorithms<T>
    {
        #region User Defined Delegate Dt
        //public static void BSort(T[] Arr, CompFuncDelDT<T,T,bool> CompFuncPtr)
        //{
        //    bool Sorted = false;

        //    for (int i = 0; (i < Arr?.Length) && (!Sorted); i++)
        //    {
        //        Sorted = true;
        //        for (int j = 0; j < Arr.Length - i - 1; j++)
        //            if (CompFuncPtr?.Invoke(Arr[j], Arr[j + 1]) == true) ///safe
        //            {
        //                SWAP(ref Arr[j], ref Arr[j + 1]);
        //                Sorted = false;
        //            }
        //    }
        //} 
        #endregion

        public static void BSort(T[] Arr, Func<T, T,bool> CompFuncPtr)
        {
            bool Sorted = false;

            for (int i = 0; (i < Arr?.Length) && (!Sorted); i++)
            {
                Sorted = true;
                for (int j = 0; j < Arr.Length - i - 1; j++)
                    if (CompFuncPtr?.Invoke(Arr[j], Arr[j + 1]) == true) ///safe
                    {
                        SWAP(ref Arr[j], ref Arr[j + 1]);
                        Sorted = false;
                    }
            }
        }



        //public static void BSort(int[] Arr)
        //{
        //    bool Sorted = false;

        //    for (int i = 0; (i < Arr?.Length) && (!Sorted); i++)
        //    {
        //        Sorted = true;
        //        for (int j = 0; j < Arr.Length - i - 1; j++)
        //            if (CompFuncs.ChkGrt(Arr[j], Arr[j + 1]))
        //            {
        //                SWAP(ref Arr[j], ref Arr[j + 1]);
        //                Sorted = false;
        //            }
        //    }
        //}

        public static void SWAP(ref T X, ref T Y)
        {
            T Temp = X;
            X = Y;
            Y = Temp;
        }

    }

    public class CompFuncs
    {
        public static bool ChkGrt(int L, int R) { return L > R; }
        public static bool ChkLwr(int L, int R) { return L < R; }
    }
}