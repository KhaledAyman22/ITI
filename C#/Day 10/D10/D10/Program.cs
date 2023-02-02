using System.Text.RegularExpressions;
using static D10.ListGenerators;
namespace D10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Implicit Typed Local Variable
            //double D1 = 15.3;

            //Console.WriteLine(D1.GetType().Name);

            ////D1 = "Hello";


            /////Implicitly Typed local Variable
            //var D2 = 16.5;

            //Console.WriteLine(D2.GetType().Name);

            ////D2 = "Hello";

            ////var D3; var D3 = default; var D3 = null; /// not valid
            //var D4 = default(bool); 
            #endregion

            #region Extension Method
            //int X = 123456;

            //Console.WriteLine($"{X} Mirrored {Int32Extensions.Mirror(X)} , {X.Mirror()}"); 
            #endregion

            #region Anonymous Types
            ////Employee E1 = new Employee() { ID = 1, Name = "Sally", Salary = 10_000 };
            ////var E2 = new Employee() { ID = 2, Name = "Mona", Salary = 12_000 };

            /////Anonymous Type
            //var E3 = new { ID = 3, Name = "Sara", Salary = 18_000M };
            /////Immutable DT
            ////E3.Salary = 500;

            //var E4 = new { ID = 5, Name = "Ali", Salary = 2000M };
            //var E5 = new { ID = 5, Name = "Ali", Salary = 2000M };

            //Console.WriteLine(E3.GetType().Name);
            //Console.WriteLine(E4.GetType().Name);

            ////Console.WriteLine(E3.GetType());

            //Console.WriteLine(E3);
            //Console.WriteLine(E4.Equals(E5));

            //Console.WriteLine($"E4 {E4.GetHashCode()}");
            //Console.WriteLine($"E5 {E5.GetHashCode()}");

            //var E6 = E5 with { Name = "Tamer" };

            //Console.WriteLine(E5);
            //Console.WriteLine(E6);
            //Console.WriteLine($"E5 {E5.GetHashCode()}");
            //Console.WriteLine($"E6 {E6.GetHashCode()}");


            ////Object E7 = new { ID = 3, Name = "Sara", Salary = 18_000M };
            ////E7. 
            #endregion

            List<int> Lst = new() { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            List<String> NameList = new() { "Ahmed Ali", "Sally Samier", "Mona Mena" };

            #region EX01 Query Syntax vs Fluent Syntax
            /////1.0 Static Function , Static Class
            //var Result = Enumerable.Where(Lst, x => x % 2 == 0);

            /////2.0 Extension Method ( for all LINQ Query Operators)
            /////Fluent Syntax
            //Result = Lst.Where(x => x % 2 == 0);

            /////3.0 Query Expression / Syntax ( for Some of LINQ Operators only , 12 only)
            /////start with from , declare Range Variable representing each and every element in Input Seq
            /////Ends with Select or Group By 
            //Result = from x in Lst
            //         where x % 2 == 0
            //         select x;

            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Deffered Execution

            /////All Linq Operators are Deffered Execution except [Casting , Single value] operators

            //var Result = Lst.Where(i => i % 2 == 0); ///Defered Excution

            //Console.WriteLine(Result.GetType());

            //Lst.AddRange(new int[] { 10, 11, 12, 13, 14 });

            //foreach (var item in Result) ///Query will be Executed
            //{
            //    Console.WriteLine(item);
            //}

            //Lst.Remove(2);
            //Lst.Remove(4);
            //Lst.Add(16);
            //Lst.Add(18);

            //Console.WriteLine("////////");

            //foreach (var item in Result) ///Query will be Executed
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Immidiate Execution
            //var Result = Lst.Where(i => i % 2 == 0).ToList(); ///Immediate Excution , Query will be Executed

            //Console.WriteLine(Result.GetType());

            //Lst.AddRange(new int[] { 10, 11, 12, 13, 14 });

            //foreach (var item in Result) 
            //{
            //    Console.WriteLine(item);
            //}

            //Lst.Remove(2);
            //Lst.Remove(4);
            //Lst.Add(16);
            //Lst.Add(18);

            //Console.WriteLine("////////");

            //foreach (var item in Result) 
            //{
            //    Console.WriteLine(item);
            //} 
            #endregion

            #region Filteration (where)
            //var Result = ProductList.Where(P => P.UnitsInStock == 0);
            //Result = from P in ProductList
            //         where P.UnitsInStock == 0
            //         select P;

            /////V2.0 Indexed where , only using Fluent Syntax
            /////i : element index in input Sequence
            //Result = ProductList.Where((P, index) => (index < 10) && (P.UnitsInStock == 0));
            #endregion

            #region Transformation , Projection (Select)

            //IEnumerable<string> Result = ProductList.Where(P => P.UnitsInStock == 0)
            //                                        .Select(P => P.ProductName);

            //Result = from P in ProductList
            //         where P.UnitsInStock == 0
            //         select P.ProductName;

            //var Result = ProductList.Where(P => P.UnitsInStock == 0)
            //                                       .Select(P => new ProductLite { ID = P.ProductID , Name = P.ProductName  });

            //Result = from P in ProductList
            //         where P.UnitsInStock == 0
            //         select new ProductLite { ID = P.ProductID, Name = P.ProductName };

            //var Result = ProductList.Where(P => P.UnitsInStock == 0)
            //                                      .Select(P => new {P.ProductName , ProductCategory = P.Category } );

            //Result = from P in ProductList
            //         where P.UnitsInStock == 0
            //         select new  { P.ProductName, ProductCategory = P.Category };

            ///V2.0 Indexed Select , valid only in Fluent Syntax
            //var Result = ProductList.Where(P => P.UnitsInStock == 0)
            //                                       .Select((P, i) => new { No = i, Name = P.ProductName });

            #endregion

            #region Select Many
            ///using multiple from in Query Syntax
            //var Result = from FullName in NameList
            //             from Name in FullName.Split(" ")
            //             where Name.Length >= 4
            //             select Name;

            //Result = NameList.SelectMany(FullName => FullName.Split(" ")).Where(Name => Name.Length >= 4);

            #endregion

            #region Ordering

            //var Result = ProductList.Where(P => P.UnitsInStock != 0)
            //                            .OrderBy(P => P.UnitPrice);

            //Result = from P in ProductList
            //         where P.UnitsInStock != 0
            //         orderby P.UnitPrice
            //         select P;


            // Result = ProductList.Where(P => P.UnitsInStock != 0)
            //                         .OrderByDescending(P => P.UnitPrice);

            //Result = from P in ProductList
            //         where P.UnitsInStock != 0
            //         orderby P.UnitPrice descending
            //         select P;

            //Result = ProductList.Where(P => P.UnitsInStock != 0)
            //                        .OrderByDescending(P => P.UnitPrice)
            //                        .ThenBy(P => P.UnitsInStock);

            //Result = from P in ProductList
            //         where P.UnitsInStock != 0
            //         orderby P.UnitPrice descending , P.UnitsInStock
            //         select P;


            //Result = ProductList.Where(P => P.UnitsInStock != 0)
            //                        .OrderByDescending(P => P.UnitPrice)
            //                        .ThenByDescending(P => P.UnitsInStock);

            //Result = from P in ProductList
            //         where P.UnitsInStock != 0
            //         orderby P.UnitPrice descending, P.UnitsInStock descending
            //         select P;


            //Department D01 = new() { ID = 1, Title = "Math" };
            //Department D02 = new() { ID = 2, Title = "Art" };


            //List<Employee> empList = new() {  
            //    new() {  ID = 5 , Name = "Sally" , Department = D01 , Salary = 5000} ,
            //    new() {  ID = 2 , Name = "Sayed" , Department = D02 , Salary = 15000} ,
            //    new() {  ID = 8 , Name = "Samir" , Department = D01 , Salary = 500} ,

            //};

            //var Result = empList.OrderBy(E => E.Salary);

            //var Result = empList.OrderBy(E => E.Department , new DepartmentCompare());

            #endregion

            #region Slicing / Particining Operators

            //var Result = ProductList.Take(10);

            //var Result = ProductList.Take(..6); ///Rane , Index

            //Result = ProductList.Skip(30);


            //for ( int i=0; i < (ProductList.Count / 10 )+1; i++)
            //{
            //    var Page = ProductList.Skip(i * 10).Take(10);

            //    foreach (var item in Page)
            //    {
            //        Console.WriteLine(item);
            //    }

            //    Console.ReadLine();
            //    Console.Clear();
            //}

            ///.Net 6 Chunck

            //var Results = ProductList.Chunk(10); /// Slice input Seq to Slices each Slice Size is 10 Elements 

            //foreach (var PrdCunk in Results)
            //{
            //    foreach (var Prd in PrdCunk)
            //        Console.WriteLine(Prd);
            //    Console.ReadLine();
            //    Console.Clear();
            //}



            //var Result = ProductList.TakeLast(10);

            //Result = ProductList.SkipLast(70);

            //var Result = ProductList.TakeWhile(P => P.UnitsInStock > 0);
            /////Take elements as long as Predicate return true , Skip at first Predicate returning false

            //Result = ProductList.SkipWhile(P => P.UnitsInStock > 0);
            /////Skip as long as Predicate return true , take the rest at first predicate returing false

            #endregion

            #region Genrators
            //var Lst01 = Enumerable.Range(0, 100);

            //var PrdLst = Enumerable.Empty<Product>(); ///Empty Seq.

            //var Result = Enumerable.Repeat("Hello", 20);

            #endregion

            #region Set Operators
            var Lst01 = Enumerable.Range(0, 100); ///0 .. 99
            var Lst02 = Enumerable.Range(50, 100); /// 50 ...149

            //var Result = Lst01.Intersect(Lst02);

            //var Result = Lst01.Except(Lst02);

            var PrdLst01 = ProductList.Take(10).ToList();
            var PrdLst02 = ProductList.Skip(5).Take(10).ToList();

            var Result = PrdLst01.ExceptBy(PrdLst02.Select(P=> P.ProductID), P => P.ProductID);
            ///replacment IEqualityComparer 

            //Result = Lst01.Union(Lst02); //remove Duplicates

            //Result = Lst01.Concat(Lst02).Distinct();

            //foreach (var item in Result)
            //{
            //    Console.Write($"{item} , ");
            //}


            #endregion

            #region Single Element Operators (Imidiate Execution)

            //var Result = ProductList.First();

            //Result = ProductList.Last();

            //Result = ProductList.First(P=> P.UnitPrice > 50);

            //Result = ProductList.Last(P => P.UnitsInStock == 0);


            List<Product> DiscountedPrds = new();
            /////if no element exists in Input Seq. , thrwo exception
            ////Result = DiscountedPrds.First();
            ////Result = DiscountedPrds.Last();
            /////if no element in Input Seq matching Predicate , Throw exception
            ////Result = ProductList.First(P => P.UnitPrice > 500);
            ////Result = ProductList.Last(P => P.UnitsInStock > 150);

            /////if no element exists in Input Seq. , return null , no Exception will be thrown
            //Result = DiscountedPrds.FirstOrDefault();
            //Result = DiscountedPrds.LastOrDefault();
            /////if no element in Input Seq matching Predicate , , return null , no Exception will be thrown
            //Result = ProductList.FirstOrDefault(P => P.UnitPrice > 500);
            //Result = ProductList.LastOrDefault(P => P.UnitsInStock > 150);

            ///.Net 6 , Define Default Value All XYZOrDefault
            //Result = DiscountedPrds.FirstOrDefault(new Product() { ProductID = -1, ProductName = "Demo Prd" });

            //IEnumerable<Product> ExpPrds = ProductList.Where(P => P.UnitPrice > 10);

            ////Result = ExpPrds[5]; /// no valid
            //Result = ExpPrds.ElementAt(5);

            //Result = ExpPrds.ElementAtOrDefault(95);


            //DiscountedPrds.Add(ProductList.First());

            //Result = DiscountedPrds.Single();
            /////return Single element in Input Seq
            /////if no elements in input Seq : Exception
            /////if more than one element in Input Seq : Exception
            ////Result = ProductList.Single();
            ////Result = ProductList.Single(P => P.UnitsInStock >500);


            //Result = ProductList.Single(P => P.ProductID == 7);


            //DiscountedPrds.Clear();

            //Result = DiscountedPrds.SingleOrDefault();
            /////return Single element in Input Seq
            /////if no elements in input Seq : return null , no exception
            /////if more than one element in Input Seq : Exception
            ////Result = ProductList.SingleOrDefault(P => P.UnitsInStock ==0);

            //Console.WriteLine(Result);
            //Console.WriteLine(Result?.ProductName??"NA");
            #endregion

            #region Aggregates (Imidiate Execution)

            //var Result = ProductList.Count();
            //Result = ProductList.Count(P=> P.UnitsInStock==0);

            //var Result = ProductList.Max();
            //Result = ProductList.Min();

            //var Result02 = ProductList.Max(P => P.UnitPrice);
            ///return Max UnitPrice

            //Console.WriteLine(Result);
            //Console.WriteLine(Result02);

            //var Prd = (from P in ProductList
            //           where P.UnitPrice == ProductList.Max(P => P.UnitPrice)
            //           select P).FirstOrDefault();

            ///.Net 6.0
            //var MxPricePrd = ProductList.MaxBy(p => p.UnitPrice);
            /////return Product with Max UnitPrice
            //var MnPricePrd = ProductList.MinBy(p => p.UnitPrice);

            //Console.WriteLine(MxPricePrd);
            
            //Console.WriteLine(Prd.ProductName);

            //Console.WriteLine( ProductList.Sum(P=> P.UnitsInStock ));
            //Console.WriteLine(ProductList.Average(P => P.UnitPrice));


            #endregion

            #region Quantifiers (return true / false)

            //Console.WriteLine(  ProductList.Any());
            /////at least on element in Seq
            //Console.WriteLine(ProductList.Any(P => P.UnitPrice < 5));
            /////at least on element in Seq match Predicate

            //Console.WriteLine(ProductList.All( P=> P.UnitsInStock >0));

            //Console.WriteLine(ProductList.SequenceEqual(DiscountedPrds));

            #endregion

            #region Zip Operator

            //int[] Arr = { 1, 2, 3, 4, 5, 6, 7, 8 };
            //string[] Names = { "Ahmed", "Ali", "Samier" };


            //var Result = Arr.Zip(Names, (i, N) => new {Id = i , Title = N }); ;

            #endregion

            #region Grouping

            //var Result = from P in ProductList
            //            where P.UnitsInStock > 0
            //            group P by P.Category;

            //var Result = ProductList.Where(P => P.UnitsInStock > 0)
            //                    .GroupBy(P => P.Category);

            //Console.WriteLine($"Result Type {Result.GetType().Name}, Group Number {Result.Count()}");


            //foreach ( var PrdGrp in Result )
            //{
            //    Console.WriteLine($"{PrdGrp.Key} with Total Product Count {PrdGrp.Count()}");
            //    foreach ( var Prd in PrdGrp)
            //    {
            //        Console.WriteLine($"....{Prd.ProductName}");
            //    }
            //}


            #endregion

            #region Let , Into 
            List<string> Names = new() { "Ahmed", "Sally", "Mai", "Mena", "Mona", "Raniem", "Mariam" };

            //var Result = from Name in Names
            //             select Regex.Replace(Name, "[AOIEUaoieu]", string.Empty)
            //             into NoVowelName /// into Define new Range Variable , no Access to Original Range Variable
            //             where NoVowelName.Length >= 3
            //             orderby NoVowelName, NoVowelName.Length descending
            //             select NoVowelName;


            //Result = Names.Select(Name => Regex.Replace(Name, "[AOIEUaoieu]", string.Empty))
            //            .Where(NoVowelName => NoVowelName.Length >= 3)
            //            .OrderBy(NV => NV)
            //            .ThenByDescending(NV => NV.Length);

            //var Result = from Name in Names
            //             let NoVowelName = Regex.Replace(Name, "[AOIEUaoieu]", string.Empty)
            //             ///Let introduce new Range Variable in Addition to Original
            //             where NoVowelName.Length >= 3
            //             orderby NoVowelName, Name.Length descending
            //             select new { original = Name, NoVowelName };

            #endregion


            //foreach (var item in Result)
            //{
            //    Console.WriteLine(item);
            //}

        }
    }

    class DepartmentCompare : IComparer<Department>
    {
        public int Compare(Department? x, Department? y)
            => x.Title.CompareTo(y.Title);
    }
}