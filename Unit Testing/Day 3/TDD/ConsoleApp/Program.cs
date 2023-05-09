// See https://aka.ms/new-console-template for more information
using ConsoleApp;

Console.WriteLine("Hello, World!");


static void RunFizzBuzz()
{
	for (int i = 1; i <= 100; i++)
	{
		Console.WriteLine(FizzBuzz.Print(i));
	}
}

RunFizzBuzz();
Console.ReadLine();