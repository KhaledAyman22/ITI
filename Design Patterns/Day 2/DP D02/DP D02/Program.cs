using DP_D02.Factory;

namespace DP_D02
{
    internal class Program
    {
        static void Main(string[] args)
        {
            WilliamsCarFactory ConcFactory = new();

            Formual1Car Car = new Formual1Car(ConcFactory);
            Car.Assemble();

            Console.WriteLine(  Car);

            Car = new Formual1Car(new Willams2026CarFactory());
            Car.Assemble();

            Console.WriteLine(Car);

        }
    }
}