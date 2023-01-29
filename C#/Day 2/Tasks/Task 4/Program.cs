using System.Diagnostics;

namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw;

            #region With Trace
            sw = Stopwatch.StartNew();
            var val1 = PresentList1(183.23, 64.11, 7, 12, new double[] { 4.53, 9.11, 4.53, 6.00, 1.04, 0.87, 2.57, 19.45, 65.59, 14.14, 16.66, 13.53 },
                                              new double[] { 12.23, 45.03, 12.23, 32.93, 6.99, 0.46, 7.34, 65.98, 152.13, 7.23, 10.00, 25.25 });

            string str = string.Join(",", val1.Item1.ToList());

            sw.Stop();

            Console.WriteLine($"Taken: {str}\nTaken Volume: {val1.Item2}/64.11\nSpent: {val1.Item3}/183.23\nElapsed: {sw.ElapsedMilliseconds}ms");

            #endregion
            
            Console.WriteLine("\n");

            #region Without trace

            sw = Stopwatch.StartNew();
            var val2 = PresentList2(183.23, 64.11, 7, 12, new double[] { 4.53, 9.11, 4.53, 6.00, 1.04, 0.87, 2.57, 19.45, 65.59, 14.14, 16.66, 13.53 },
                                              new double[] { 12.23, 45.03, 12.23, 32.93, 6.99, 0.46, 7.34, 65.98, 152.13, 7.23, 10.00, 25.25 });

            sw.Stop();

            Console.WriteLine($"Spent: {val2}/183.23\nElapsed: {sw.ElapsedMilliseconds}ms");

            #endregion
        }

        public static Tuple<List<int>, double, double> PresentList1(double budget, double bagVolume, int people, int Npresents, double[] presentVolume, double[] presentPrice)
        {
            return Recurse(0, new List<int>(), 0, 0, 0); ;


            Tuple <List<int>, double,double> Recurse(int i, List<int> taken, int j,double vol, double spent)
            {
                if (i >= Npresents) return new Tuple<List<int>, double, double>(taken, vol, spent);

                List<int> tmp1 = new(taken);
                List<int> tmp2 = new(taken);
                int left = Npresents - i;
                tmp1.Add(i);

                Tuple<List<int>, double, double> with = null, without = null;

                if (left - 1 >= people - (j % people))
                    without = Recurse(i + 1, tmp2, j, vol, spent);

                if (
                    ((j + 1) % people == 0 || left - 1 >= people - ((j + 1) % people))
                    && vol + presentVolume[i] <= bagVolume
                    && spent + presentPrice[i] <= budget
                   )
                    
                    with = Recurse(i + 1, tmp1, j + 1, vol + presentVolume[i], spent + presentPrice[i]);

                double w = with?.Item3 ?? 0, wo = without?.Item3 ?? 0;

                if(w == wo) return new Tuple<List<int>, double, double>(taken, vol, spent);
                return w > wo ? with : without;
            }
        }


        public static double PresentList2(double budget, double bagVolume, int people, int Npresents, double[] presentVolume, double[] presentPrice)
        {
            return Recurse(0, 0, 0, 0);


             double Recurse(int i, int taken,double vol, double spent)
             {
                if (i >= Npresents)
                {
                    if (taken % people == 0) return spent;
                    else return 0;
                }
                
                int left = Npresents - i;

                if(left < people - (taken % people)) 
                    return spent;

                double with = 0, without = 0;

                if (left - 1 >= people - (taken % people))
                    without = Recurse(i + 1, taken, vol, spent);

                if (
                    ((taken + 1) % people == 0 || left - 1 >= people - ((taken + 1) % people))
                    && vol + presentVolume[i] <= bagVolume 
                    && spent + presentPrice[i] <= budget
                   )
                    with = Recurse(i + 1, taken + 1, vol + presentVolume[i], spent + presentPrice[i]);


                return Math.Max(with, Math.Max(without, spent));
            }
        }
    }
}