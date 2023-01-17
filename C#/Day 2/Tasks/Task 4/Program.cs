namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(
                PresentList(183.23, 64.11, 7, 12, new double[]{ 4.53 , 9.11 , 4.53 , 6.00 , 1.04, 0.87, 2.57, 19.45, 65.59 , 14.14, 16.66, 13.53},
                                              new double[] {12.23, 45.03, 12.23, 32.93, 6.99, 0.46, 7.34, 65.98, 152.13, 7.23 , 10.00, 25.25})
            );
        }
        
        public static double PresentList(double budget, double bagVolume, int people, int Npresents, double[] presentVolume, double[] presentPrice)
        {

            List<Tuple<List<int>, double, double>> list = new List<Tuple<List<int>, double, double>>();

            for (int i = 0; i < Npresents; i++)
            {
                var l = new List<int>();
                list.Add(Recurse(i, ref l, 0, 0));
            }

            var max = list.Max((l) => l.Item3);
            var index = list.Where((l) => l.Item3 == max).SingleOrDefault();
            return max;

            Tuple<List<int>,double,double> Recurse(int i, ref List<int> taken, double vol, double spent)
            {
                if (i >= Npresents) return new Tuple<List<int>, double, double>(taken, vol, spent);

                var tmp1 = new List<int>(taken) { i };
                var tmp2 = new List<int>(taken);
                Tuple<List<int>, double, double> with = null, without = null;

                without = Recurse(i + 1, ref tmp2, vol, spent);

                if (vol + presentVolume[i] <= bagVolume && spent + presentPrice[i] <= budget)
                {
                    with = Recurse(i + 1, ref tmp1, vol + presentVolume[i], spent + presentPrice[i]);
                }

                if (with == null) return without;
                else return with.Item3 > without.Item3 ? with : without;

            }
        }

    }
}