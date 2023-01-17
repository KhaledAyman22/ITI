namespace Task_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a statment:");
            string statment = Console.ReadLine();

            Console.WriteLine("\n\nReversed statment is:");
            Console.WriteLine(string.Join(" ", statment.Split(' ').Reverse()));
        }
    }
}