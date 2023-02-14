namespace D11
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Point P1 = new() { X = 10, Y = 10 };
            Point P2 = new() { X = 5, Y = 15 };
            Point P3 = new() { X = 10, Y = 10 };
            Point P4 = P1;

            Console.WriteLine($"P1 {P1.GetHashCode()}");
            Console.WriteLine($"P2 {P2.GetHashCode()}");
            Console.WriteLine($"P3 {P3.GetHashCode()}");
            Console.WriteLine($"P4 {P4.GetHashCode()}");

            Dictionary<Point, String> MyD = new();

            MyD.Add(P1, "Left Corner");
            MyD.Add(P2, "Right Corner");
            
            if ( MyD.TryAdd(P3 , "New Left Corner"))
                Console.WriteLine("P3 Added");
            else
                Console.WriteLine("P3 Already Existing");

            //MyD.Add(P3, "Left Edge");
            ////Exception
            ///MyD.Add(P4, "LEft Corner");


            if (MyD.TryGetValue(P3, out string Str))
                Console.WriteLine(Str);
            else
                Console.WriteLine("P3 Not Found");


            //if (MyD.TryGetValue(P4, out Str))
            //    Console.WriteLine(Str);
            //else
            //    Console.WriteLine("P4 Not Found");

            ///Change P2 State 
            //P2.Y = 50;
            ///Change P2 Identity , Value was assosiated with Old identity will not be found
            ///Lost among Buckets
            ///1. Remove Key Value Pair First 
            ///2. P2 new Identity 
            ///3. Add Key Value Pair based on new identity

            ///1.
            //MyD.Remove(P2);
            ///2.
            //P2 = new Point() { X = 50, Y = 50 };
            ///3.
            //MyD.Add(P2, "Right Edge");

            ///After overriding Gethashcode , Equals to reflect Object State
            //P2.X = 100;
            //Console.WriteLine($"P2 {P2.GetHashCode()}");
            ///Value Lost among Buckets 
            ///Key must be Immutable Type
            
            if (MyD.TryGetValue(P2, out string Str2))
                Console.WriteLine(Str2);
            else
                Console.WriteLine("P2 Not Found");


        }
    }
}