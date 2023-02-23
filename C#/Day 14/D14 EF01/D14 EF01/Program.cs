using D14_EF01.Context;
using D14_EF01.Entities;
using Microsoft.EntityFrameworkCore;

namespace D14_EF01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (LibraryContext context= new LibraryContext()) 
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                /////L2E Query
                /////Select
                //var Result = context.Titles.FirstOrDefault();

                //Console.WriteLine(Result?.AuthorName??"NA");

                #region Insert
                //Title title = new() { AuthorName = "GRRM", Price = 13.5M, PromotionalPrice = 12 };

                //context.Add(title);
                //context.Titles.Add(title);
                ///Local Reposatry (Titles)

                ///Commit Changes to DB

                //Title T2 = new() { AuthorName = "JKR", Price = 20 };

                //Console.WriteLine($"{context.Entry(T2).State}");

                //context.Add(T2);
                //Console.WriteLine($"{context.Entry(T2).State}");

                //context.SaveChanges();
                ////Console.WriteLine(title.ID);
                //Console.WriteLine($"{context.Entry(T2).State}");

                #endregion

                #region Update

                //var Result = (from T in context.Titles
                //              where T.PromotionalPrice == null
                //              select T).First();

                //Result.PromotionalPrice = 0.75M * Result.Price;
                #endregion


                //var T = context.Titles.FirstOrDefault(t => t.AuthorName == "JKR");

                //if (T != null)
                //    context.Titles.Remove(T);

                context.Add(new Branch() { City = "Cairo", OpenHour = 10 , ZipCode="12111" });

                context.SaveChanges();


            }
        }
    }
}