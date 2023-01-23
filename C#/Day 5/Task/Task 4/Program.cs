namespace Task_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Duration D = new Duration(1, 10, 15);
            Console.WriteLine("D");
            Console.WriteLine($"Result: {D}");
            Console.WriteLine($"Expected: Hours: 1, Minutes :10 , Seconds :15\n");


            Duration D1 = new Duration(3600);
            Console.WriteLine("D1");
            Console.WriteLine($"Result: {D1}");
            Console.WriteLine($"Expected: Hours: 1, Minutes: 0 , Seconds: 0\n");

            Duration D2 = new Duration(7800);
            Console.WriteLine("D2");
            Console.WriteLine($"Result: {D2}");
            Console.WriteLine($"Expected: Hours: 2, Minutes: 10 , Seconds: 0\n");

            Duration D3 = new Duration(666);
            Console.WriteLine("D3");
            Console.WriteLine($"Result: {D3}");
            Console.WriteLine($"Expected: Minutes :11 , Seconds :6\n");


            Console.WriteLine("D3 = D1 + D2");
            Console.WriteLine($"D3 = {D1} + {D2}");
            D3 = D1 + D2;
            Console.WriteLine($"D3 = {D3}\n");
            //////////////////////////////////////////
            Console.WriteLine("D3 = D1 + 7800");
            Console.WriteLine($"D3 =  {D1} +  {D2}");
            D3 = D1 + 7800;
            Console.WriteLine($"D3 = {D3}\n");
            //////////////////////////////////////////
            Console.WriteLine("D3 = 666 + D3");
            Console.WriteLine($"D3 = {new Duration(666)} + {D3}");
            D3 = 666 + D3;
            Console.WriteLine($"D3 = {D3}\n");
            //////////////////////////////////////////
            Console.WriteLine("D3 = D1++");
            Console.WriteLine($"D3 = {D1}++");
            D3 = D1++;
            Console.WriteLine($"D3 = {D3}");
            Console.WriteLine($"D1 = {D1}\n");
            //////////////////////////////////////////
            Console.WriteLine("D3 = --D2");
            Console.WriteLine($"D3 = --{D2}");
            D3 = --D2;
            Console.WriteLine($"D3 = {D3}\n");
            //////////////////////////////////////////
            Console.WriteLine("D1 -= D2");
            Console.WriteLine($"{D1} -= {D2}");
            D1 -= D2;
            Console.WriteLine($"D1 = {D1}\n");
            //////////////////////////////////////////
            Console.WriteLine("if (D1 > D2)");
            if(D1 > D2) Console.WriteLine("True\n");
            else Console.WriteLine("False\n");
            //////////////////////////////////////////
            Console.WriteLine("if (D1 <= D2)");
            if(D1 <= D2) Console.WriteLine("True\n");
            else Console.WriteLine("False\n");
            //////////////////////////////////////////
            Console.WriteLine("if (D1)");
            if(D1) Console.WriteLine("True\n");
            else Console.WriteLine("False\n");
            //////////////////////////////////////////
            Console.WriteLine("DateTime Obj = (DateTime)D1");
            DateTime Obj = (DateTime)D1;
            Console.WriteLine($"D1 = {D1}");
            Console.WriteLine($"obj = {Obj}\n");
            //////////////////////////////////////////
        }
    }
}