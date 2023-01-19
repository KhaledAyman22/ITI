using System.Diagnostics;

namespace Task_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
           int x = 100000000;

            #region using strings
            {
                Stopwatch sw = Stopwatch.StartNew();
                int count = 0;

                for (int i = 0; i < x; i++)
                {
                    string s = i.ToString();
                    for (int j = 0; j < s.Length; j++)
                    {
                        if (s[j] == '1') count++;
                    }
                }
                sw.Stop();

                Console.WriteLine($"Time elapsed using strings is: {sw.ElapsedMilliseconds}, Count is: {count}");
            }
            #endregion

            Console.WriteLine();

            #region using mod
            {
                Stopwatch sw = Stopwatch.StartNew();
                int count = 0;

                for (int i = 0; i < x; i++)
                {
                    int tmp = i;
                    while(tmp != 0)
                    {
                        if (tmp % 10 == 1) count++;
                        tmp /= 10;
                    }
                }
                sw.Stop();

                Console.WriteLine($"Time elapsed using mod is: {sw.ElapsedMilliseconds}, Count is: {count}");
            }
            #endregion

            Console.WriteLine();

            #region using equation
            {
                Stopwatch sw = Stopwatch.StartNew();
                
                int count = x * (x.ToString().Length-1) / 10;

                sw.Stop();

                Console.WriteLine($"Time elapsed using mathematical equation is: {sw.ElapsedMilliseconds}, Count is: {count}");
            }
            #endregion
        }
    }
}