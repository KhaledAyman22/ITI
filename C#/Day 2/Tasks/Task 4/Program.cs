using System.Diagnostics;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw;
            TimeSpan ts;
            double val;

            #region With Trace
            sw = Stopwatch.StartNew();
            val = PresentList1(183.23, 64.11, 7, 12, new double[] { 4.53, 9.11, 4.53, 6.00, 1.04, 0.87, 2.57, 19.45, 65.59, 14.14, 16.66, 13.53 },
                                              new double[] { 12.23, 45.03, 12.23, 32.93, 6.99, 0.46, 7.34, 65.98, 152.13, 7.23, 10.00, 25.25 });

            sw.Stop();

            Console.WriteLine("Spent: " + val + "\nElapsed: " + sw.ElapsedMilliseconds + "ms");

            #endregion
            
            Console.WriteLine("\n\n\n\n\n");

            #region Without trace

            sw = Stopwatch.StartNew();
            val = PresentList1(183.23, 64.11, 7, 12, new double[] { 4.53, 9.11, 4.53, 6.00, 1.04, 0.87, 2.57, 19.45, 65.59, 14.14, 16.66, 13.53 },
                                              new double[] { 12.23, 45.03, 12.23, 32.93, 6.99, 0.46, 7.34, 65.98, 152.13, 7.23, 10.00, 25.25 });

            sw.Stop();

            ts = sw.Elapsed;
            
            Console.WriteLine("Spent: " + val + "\nElapsed: " + sw.ElapsedMilliseconds + "ms");

            #endregion

            Console.Read();
        }

        public static double PresentList1(double budget, double bagVolume, int people, int Npresents, double[] presentVolume, double[] presentPrice)
        {

            Tuple<int[], double, double>[] list = new Tuple<int[], double, double>[Npresents-1];
            double max = 0;

            for (int i = 0; i < Npresents-1; i++)
            {
                int[] arr = new int[Npresents];
                arr[0] = i;
                list[i] = Recurse(i+1, ref arr, 1,presentVolume[i], presentPrice[i]);
                max = list[i].Item3 > max? list[i].Item3 : max;
            }

            //var max = list.Max((l) => l.Item3);
            //var index = list.Where((l) => l.Item3 == max).SingleOrDefault();
            return max;


            Tuple <int[],double,double> Recurse(int i, ref int[] taken, int j,double vol, double spent)
            {
                if (i >= Npresents) return new Tuple<int[], double, double>(taken, vol, spent);

                int[] tmp1 = (int[])taken.Clone();
                int[] tmp2 = (int[])taken.Clone();
                
                tmp1[j] = i;
                
                Tuple<int[], double, double> with = null, without = null;

                if(taken.Length + Npresents - i - 1 >= people)
                    without = Recurse(i + 1, ref tmp2, j, vol, spent);

                if (vol + presentVolume[i] <= bagVolume && spent + presentPrice[i] <= budget)
                    with = Recurse(i + 1, ref tmp1, j+1, vol + presentVolume[i], spent + presentPrice[i]);


                if(without == null && with == null) return new Tuple<int[], double, double> ( taken, vol, spent);
                else if (with == null && without != null) return without;
                else if (with != null && without == null) return with;
                else return with.Item3 > without.Item3 ? with : without;

            }
        }


        public static double PresentList2(double budget, double bagVolume, int people, int Npresents, double[] presentVolume, double[] presentPrice)
        {

            double max = 0, tmp;

            for (int i = 0; i < Npresents - 1; i++)
            {
                tmp = Recurse(i + 1, 1,presentVolume[i], presentPrice[i]);
                max = tmp > max ? tmp : max;
            }

            return max;


            double Recurse(int i, int taken,double vol, double spent)
            {
                if (i >= Npresents) return spent;

                double with = 0, without = 0;

                if (taken + Npresents - i - 1 >= people)
                    without = Recurse(i + 1, taken, vol, spent);

                if (vol + presentVolume[i] <= bagVolume && spent + presentPrice[i] <= budget)
                    with = Recurse(i + 1, taken, vol + presentVolume[i], spent + presentPrice[i]);


                if (without == 0 && with == 0) return spent;
                else if (with == 0 && without != 0) return without;
                else if (with != 0 && without == 0) return with;
                else return with > without? with : without;

            }
        }
    }
}