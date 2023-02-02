namespace Task
{
    public static class Helpers
    {
        public static void PrintList<T>(this IEnumerable<T> ls)
        {
            foreach (var item in ls)
            {
                Console.WriteLine(item.ToString());
            }
        }

        public static string StringifyList<T>(this IEnumerable<T> ls)
        {
            return string.Join("\n\t", ls);
        }

        public static void PrintGroup<T1,T2>(this IEnumerable<IGrouping<T1, T2>> groups)
        {
            foreach (var nameGroup in groups)
            {
                Console.WriteLine(nameGroup.Key);
                foreach (var item in nameGroup)
                {
                    Console.WriteLine(item.ToString());
                }
                Console.WriteLine();
            }
        }
    }
}