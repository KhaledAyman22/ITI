using CompanyConsoleAPP.Context;
using CompanyConsoleAPP.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace CompanyConsoleAPP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///Original Style for Using Statment
            //using (CompanyContext context = new CompanyContext())
            //{
            //}

            using CompanyContext context = new CompanyContext();

            ///Instead of PMC Command : Update-Database
            context.Database.Migrate();

            //context.Add
            //    (new Employee()
            //    {
            //        FName = "Ahmed", LName = "Ali", Salary = 5000
            //    }
            //    );


            //var E = context.Employees.First();

            //E.Email = "Ahmed.Ali@CompanyEmail.com";
            //E.PhoneNumber = "0111111111";

            //Console.WriteLine($"Number of Rows Affected {context.SaveChanges()}");

        }
    }
}