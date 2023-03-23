using System.Diagnostics;
using System.Linq;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;


#region Manual Benchmarcking
//var stopWatch = new Stopwatch();
//stopWatch.Start();
//new ComputePrimeNumbers().ExecuteSeq();
//stopWatch.Stop();
//Console.WriteLine("Seq");
//Console.WriteLine(stopWatch.ElapsedMilliseconds);

//stopWatch = new Stopwatch();
//stopWatch.Start();
//new ComputePrimeNumbers().ExecuteParallel();
//stopWatch.Stop();
//Console.WriteLine("Parallel");
//Console.WriteLine(stopWatch.ElapsedMilliseconds); 
#endregion

var Summary = BenchmarkRunner.Run<ComputePrimeNumbers>();


//foreach (var item in PrimeNumbers)
//{
//    Console.Write( $"{item} , " );
//}

public class ComputePrimeNumbers
{
    [Benchmark]
    public void ExecuteSeq ()
    {
        var Numbers = Enumerable.Range(3, 1_000_000 - 3);

        var PrimeNumbers = (from n in Numbers
                            where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                            select n).ToList();
        Console.WriteLine(  $"{PrimeNumbers.Count}");
    }
    [Benchmark]
    public void ExecuteParallel()
    {
        var Numbers = Enumerable.Range(3, 1_000_000 - 3);
       
        ///PLINQ
        var PrimeNumbers = (from n in Numbers.AsParallel()/*.AsOrdered()*/
                            where Enumerable.Range(2, (int)Math.Sqrt(n)).All(i => n % i > 0)
                            select n).ToList();
        
        Console.WriteLine($"{PrimeNumbers.Count}");
    }


}