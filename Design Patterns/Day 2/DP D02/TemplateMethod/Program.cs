namespace TemplateMethod
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ABSAlgorithm algorithm = new ConcAlgorithm01();
            algorithm.DoSomeAlgorithmWork();

            algorithm = new ConcAlgorithm02();
            algorithm.DoSomeAlgorithmWork();
        }
    }
}