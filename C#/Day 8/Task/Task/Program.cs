namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///User Def
            LibraryEngine.UD_Delegate UD_Ptr = new(BookFunctions.GetTitle);
           
            ///BCL
            Func<Book, string> BCL_Ptr = new(BookFunctions.GetAuthors);
            
            ///Anonymous
            Func<Book, string> Anon_Ptr = delegate (Book b) { return b.ISBN; };
            
            ///Lambda
            Func<Book, DateTime> Lambda_Ptr = b => b.PublicationDate;


            List<Book> bList = new()
            {
                new("1", "Book A", new[] { "Ahmed", "Ali", "Amr"}   , DateTime.Now, 100),
                new("2", "Book B", new[] { "Kareem", "Wael"}        , DateTime.Now, 200),
                new("3", "Book C", new[] { "Eman", "Mona", "Nader"} , DateTime.Now, 300),
                new("4", "Book D", new[] { "Yasser"}                , DateTime.Now, 400),
                new("5", "Book E", new[] { "Sara"}                  , DateTime.Now, 500),
            };

            Console.WriteLine("User Defined Delegate");
            LibraryEngine.ProcessBooksUD(bList, UD_Ptr);
            Console.WriteLine();

            Console.WriteLine("BCL Delegate");
            LibraryEngine.ProcessBooks(bList, BCL_Ptr);
            Console.WriteLine();

            Console.WriteLine("Anon Function Delegate");
            LibraryEngine.ProcessBooks(bList, Anon_Ptr);
            Console.WriteLine();

            Console.WriteLine("Lambda Delegate");
            LibraryEngine.ProcessBooks(bList, Lambda_Ptr);
            Console.WriteLine();

            #region Inline version
            //Console.WriteLine("User Defined Delegate");
            //LibraryEngine.ProcessBooksUD(bList, new(BookFunctions.GetTitle));
            //Console.WriteLine();

            //Console.WriteLine("BCL Delegate");
            //LibraryEngine.ProcessBooks(bList, new Func<Book, string>(BookFunctions.GetAuthors));
            //Console.WriteLine();

            //Console.WriteLine("Anon Function Delegate");
            //LibraryEngine.ProcessBooks(bList, delegate (Book b) { return b.ISBN; });
            //Console.WriteLine();

            //Console.WriteLine("Lambda Delegate");
            //LibraryEngine.ProcessBooks(bList, b => b.PublicationDate);
            //Console.WriteLine(); 
            #endregion
        }
    }
}