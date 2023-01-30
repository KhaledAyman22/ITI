namespace Task
{
    internal class LibraryEngine
    {  
        public delegate string UD_Delegate(Book b);

        public static void ProcessBooks<T>(List<Book> bList , Func<Book, T>fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

        public static void ProcessBooksUD(List<Book> bList, UD_Delegate fPtr)
        {
            foreach (Book B in bList)
            {
                Console.WriteLine(fPtr(B));
            }
        }

    }

}
