namespace Task_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter array size: ");
            int size = Convert.ToInt32(Console.ReadLine());

            int[] arr = new int[size];

            for (int i = 0; i < size; i++)
            {
                Console.Write($"Enter element #{i + 1}: ");
                int inpt = Convert.ToInt32(Console.ReadLine());
                arr[i] = inpt;
            }

            var distinct = arr.Distinct();
            int max = -1, elem1 = -1, elem2 = -1;

            foreach (var item in distinct)
            {
                int start = Array.IndexOf(arr, item);
                int end = Array.LastIndexOf(arr, item);
                if (end - start > max)
                { 
                    max = end - start;
                    elem1 = start;
                    elem2 = end;
                }
            }
            Console.WriteLine($"The maximum space is between element at #{elem1+1} and #{elem2+1} with a value of: {max}");
        }
    }
}