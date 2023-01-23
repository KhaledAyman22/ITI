namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size, count = 0;

            #region Read Size
            {
                Console.Write("Enter array size: ");
                string tmp = Console.ReadLine();
                while (!int.TryParse(tmp, out size))
                {
                    Console.Clear();
                    Console.Write("Enter array size: ");
                    tmp = Console.ReadLine();
                }

                Console.Clear();
            }
            #endregion
            
            Point3D[] points = new Point3D[size];

            while (count < size)
            {
                Point3D tmp = ReadPoint(ref count);
                if (tmp != null)
                {
                    points[count] = tmp;
                    count++;
                }
            }


            Console.Clear();

            Console.WriteLine($"P1: {points[0]}");
            Console.WriteLine($"P2: {points[1]}\n");

            Console.WriteLine($"P1 == P2? --> {points[0] == points[1]}\n");
            Console.WriteLine($"P1.Equals(P2)? --> {points[0].Equals(points[1])}\n");

        }

        static Point3D ReadPoint(ref int count)
        {
            Console.Clear();
            Console.Write($"Enter point #{count + 1} coordinates: ");
            string[] coords_s = Console.ReadLine().Split(',');
            double[] coords = new double[3];

            for (int i = 0; i < 3; i++)
            {
                double tmp;

                if (!double.TryParse(coords_s[i], out tmp))
                {
                    Console.WriteLine("Error couldn't parse the coordinates");
                    return null;
                }
                
                coords[i] = tmp;
            }

            return new Point3D(coords[0], coords[1], coords[2]);
        }
    }
}