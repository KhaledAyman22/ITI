using Microsoft.VisualBasic;
using System.Globalization;
using System;

namespace Task
{
    internal partial class Program
    {
        static void Main(string[] args)
        {
            string[] EnglishDictionary = File.ReadAllLines("dictionary_english.txt");

            var ProductList = ListGenerators.ProductList;
            var CustomerList = ListGenerators.CustomerList;

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/filtering-data
            #region LINQ - Restriction Operators
            {
                PrintHeader("1- LINQ - Restriction Operators");

                Print("1.Find all products that are out of stock.",
                       ProductList.Where(p => p.UnitsInStock == 0));

                Print("2.Find all products that are in stock and cost more than 3.00 per unit.",
                       ProductList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3));

                string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Print("3.Returns digits whose name is shorter than their value.",
                       Arr.Where((s, i) => s.Length < i));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/element-operations
            #region LINQ - Element Operators
            {
                PrintHeader("2- LINQ - Element Operators");

                Print("1.Get first Product out of Stock",
                       ProductList.FirstOrDefault(p => p.UnitsInStock == 0));

                Print("2.Return the first product whose Price > 1000, unless there is no match, in which case null is returned.",
                      ProductList.FirstOrDefault(p => p.UnitPrice > 1000));

                int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                Print("3.Retrieve the second number greater than 5.",
                      Arr.Where(n => n > 5).Skip(1).FirstOrDefault());
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/set-operations
            #region LINQ - Set Operators
            {
                PrintHeader("3- LINQ - Set Operators");

                Print("1.Find the unique Category names from Product List.",
                      ProductList.Select(p => p.Category).Distinct());

                Print("2.Produce a Sequence containing the unique first letter from both product and customer names.",
                      ProductList.Select(p => p.ProductName[0])
                                 .Union(CustomerList.Select(c => c.Name[0])));

                Print("3.Create one sequence that contains the common first letter from both product and customer names.",
                      ProductList.Select(p => p.ProductName[0])
                                 .Intersect(CustomerList.Select(c => c.Name[0])));

                Print("4.Create one sequence that contains the first letters of product names that are not also first letters of customer names.",
                      ProductList.Select(p => p.ProductName[0])
                                 .Except(CustomerList.Select(c => c.Name[0])));

                Print("5.Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates",
                      ProductList.Select(p => p.ProductName[^3..])
                                 .Concat(CustomerList.Select(c => c.Name[^3..])));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/aggregation-operations
            #region LINQ - Aggregate Operators
            {
                PrintHeader("4- LINQ - Aggregate Operators");

                int[] Arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                Print("1.Uses Count to get the number of odd numbers in the array.",
                      Arr1.Count(n => n % 2 == 1));

                Print("2.Return a list of customers and how many orders each has.",
                      CustomerList.Select(c => new { c.Name, OrderCount = c.Orders.Length }));

                Print("3.Return a list of categories and how many products each has",
                      ProductList.GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, ProductCount = g.Count() }));

                int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                Print("4.Get the total of the numbers in an array.", Arr2.Sum());

                Print("5.Get the total number of characters of all words in dictionary_english.txt.",
                      EnglishDictionary.Sum(word => word.Length));

                Print("6.Get the total units in stock for each product category.",
                      ProductList.GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, TotalInStock = g.Sum(p=>p.UnitsInStock) }));

                Print("7.Get the length of the shortest word in dictionary_english.txt.", EnglishDictionary.Min(w => w.Length));

                Print("8.Get the cheapest price among each category's products",
                      ProductList.GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, Cheapest = g.Min(p => p.UnitPrice) }));

                var tmp1 = from p in ProductList
                           group p by p.Category into g
                           let minPrice = g.Min(x => x.UnitPrice)
                           let minProd = g.Where(x => x.UnitPrice == minPrice)
                           select new { Category = g.Key, Products = minProd.StringifyList() };
                Print("9.Get the products with the cheapest price in each category(Use Let)", tmp1);

                Print("10.Get the length of the longest word in dictionary_english.txt.", EnglishDictionary.Max(w => w.Length));

                Print("11.Get the most expensive price among each category's products.",
                      ProductList.GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, MostExpensive = g.Max(p => p.UnitPrice) }));

                var tmp2 = from p in ProductList
                       group p by p.Category into g
                       let maxPrice = g.Max(x => x.UnitPrice)
                       let maxProd = g.Where(x => x.UnitPrice == maxPrice)
                       select new { Category = g.Key, Products = maxProd.StringifyList() };
                Print("12.Get the products with the most expensive price in each category.", tmp2);

                Print("13.Get the average length of the words in dictionary_english.txt.", EnglishDictionary.Average(w => w.Length));

                Print("14.Get the average price of each category's products.",
                      ProductList.GroupBy(p => p.Category)
                                 .Select(g => new { Category = g.Key, Average = g.Average(p => p.UnitPrice) }));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/sorting-data
            #region LINQ - Ordering Operators
            {
                PrintHeader("5- LINQ - Ordering Operators");

                Print("1.Sort a list of products by name", ProductList.OrderBy(p => p.ProductName));

                string[] Arr1 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                Print("2.Uses a custom comparer to do a case-insensitive sort of the words in an array.",
                      Arr1.OrderBy(s => s, new CustomStringComparer()));

                Print("3.Sort a list of products by units in stock from highest to lowest.",
                      ProductList.OrderByDescending(p => p.UnitsInStock));

                string[] Arr2 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Print("4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.",
                      Arr2.OrderBy(s => s.Length).ThenBy(s => s));

                string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                Print("5.Sort first by word length and then by a case-insensitive sort of the words in an array.",
                      words.OrderBy(s => s.Length).ThenBy(s => s, new CustomStringComparer()));

                Print("6.Sort a list of products, first by category, and then by unit price, from highest to lowest.",
                      ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice));

                string[] Arr3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
                Print("7.Sort first by word length and then by a case-insensitive descending sort of the words in an array.",
                      words.OrderBy(s => s.Length).ThenByDescending(s => s, new CustomStringComparer()));

                string[] Arr4 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
                Print("8.Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.",
                      Arr4.Where(n => n[^2] == 'i'));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/partitioning-data
            #region LINQ - Partitioning Operators
            {
                PrintHeader("6- LINQ - Partitioning Operators");

                Print("1.Get the first 3 orders from customers in Washington",
                      CustomerList.Where(c => c.City == "Washington")
                                  .Select(c => c.Orders).Take(3));

                Print("2.Get all but the first 2 orders from customers in Washington.",
                    CustomerList.Where(c => c.City == "Washington")
                                .Select(c => c.Orders).Skip(2));

                int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                Print("3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array.",
                      numbers.TakeWhile((n, i) => n >= i));

                Print("4.Get the elements of the array starting from the first element divisible by 3.", 
                      numbers.SkipWhile(n => n % 3 != 0));

                Print("5.Get the elements of the array starting from the first element less than its position.", 
                      numbers.SkipWhile((n, i) => n >= i));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/projection-operations
            #region LINQ - Projection Operators
            {
                PrintHeader("7- LINQ - Projection Operators");

                string[] words = { "aPPLE", "BlUeBeRrY", "cHeRry" };
                Print("1.Return a sequence of just the names of a list of products.", words.Select(w => w));

                Print("2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).",
                      words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() }));

                Print("3.Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.",
                      ProductList.Select(p => new { p.ProductID, Price = p.UnitPrice }));

                int[] Arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
                Print("4.Determine if the value of ints in an array match their position in the array.",
                      Arr.Select((n, i) => n == i));

                int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
                int[] numbersB = { 1, 3, 5, 7, 8 };
                Print("5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.",
                    numbersA.SelectMany(a => numbersB, (a, b) => new { A = a, B = b }).Where(p => p.A < p.B));

                Print("6.Select all orders where the order total is less than 500.00.",
                      CustomerList.SelectMany(c => c.Orders).Where(o => o.Total < 500));

                Print("7.Select all orders where the order was made in 1998 or later.",
                      CustomerList.SelectMany(c => c.Orders).Where(o => o.OrderDate.Year >= 1998));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/quantifier-operations
            #region LINQ - Quantifiers
            {
                PrintHeader("8- LINQ - Quantifiers");

                Print("1.Determine if any of the words in dictionary_english.txt contain the substring 'ei'.", EnglishDictionary.Any(s => s.Contains("ei")));

                Print("2.Return a grouped list of products only for categories that have at least one product that is out of stock.",
                      ProductList.Where(p => ProductList.Where(pr=> p.Category == pr.Category)
                                                        .Any(pr => pr.UnitsInStock == 0))
                                 .GroupBy(p => p.Category));

                Print("3.Return a grouped list of products only for categories that have all of their products in stock.",
                      
                ProductList.Where(p => ProductList.Where(pr => p.Category == pr.Category)
                                                  .All(pr => pr.UnitsInStock != 0))
                           .GroupBy(p => p.Category));
            }
            #endregion

            //https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/grouping-data
            #region LINQ - Grouping Operators
            {
                PrintHeader("9- LINQ - Grouping Operators");

                List<int> nums = Enumerable.Range(0, 14).ToList();
                List<int> rem = new() { 0, 1, 2, 3, 4 };
                Print("1.Use group by to partition a list of numbers by their remainder when divided by 5.",
                       nums.SelectMany(n => rem, (n, r) => new { n, r })
                           .Where(pair => pair.n % 5 == pair.r)
                           .GroupBy(pair => pair.n % 5));

                goto nxt;
                Print("2.Uses group by to partition a list of words by their first letter.",
                       EnglishDictionary.GroupBy(w => w[0]));
                nxt:

                string[] Arr = { "from", "salt", "earn", "last", "near", "form" };
                Print("3.Consider this Array as an Input Use Group By with a custom comparer that matches words that are consists of the same Characters Together",
                       Arr.GroupBy(w => w, new AnagramEqualityComparer()));
            }
            #endregion
        }

        public static void Print<T>(string str, IEnumerable<T> values)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
            if (values.Count() == 0) Console.WriteLine("None");
            else values.PrintList();
            Console.WriteLine();
        }
        
        public static void Print<T1,T2>(string str, IEnumerable<IGrouping<T1, T2>> values)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
            if (values == null) Console.WriteLine("NULL");
            else values.PrintGroup();
            Console.WriteLine();
        }
        
        public static void Print(string str, object value)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(str);
            Console.ResetColor();
            if (value == null) Console.WriteLine("NULL");
            else Console.WriteLine(value.ToString());
            Console.WriteLine();
        }

        public static void PrintHeader(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition((Console.WindowWidth - str.Length) / 2, Console.CursorTop);
            Console.WriteLine(str);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}