using System.Runtime.ConstrainedExecution;
using System.Runtime.Intrinsics.X86;
using System;

namespace Task
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Department department = new() { DeptID = 1, DeptName = "Dept 1" };
            Club club = new() { ClubID = 1, ClubName = "Club 1" };
            BoardMember boardMember = new() { EmployeeID = 1, BirthDate = new DateTime(1955, 1, 1), VacationStock = 20 };
            SalesPerson salesPerson = new() { EmployeeID = 2, BirthDate = new DateTime(1955, 1, 1), AchievedTarget = 0, VacationStock = 20 };
            Employee employee = new() { EmployeeID = 3, BirthDate = new DateTime(1955, 1, 1), VacationStock = 20 };

            department.AddStaff(boardMember);
            club.AddMember(boardMember);

            department.AddStaff(salesPerson);
            club.AddMember(salesPerson);

            department.AddStaff(employee);
            club.AddMember(employee);


            boardMember.RequestVacation(DateTime.Now, DateTime.Now.AddDays(40));
            salesPerson.RequestVacation(DateTime.Now, DateTime.Now.AddDays(40));
            employee.RequestVacation(DateTime.Now, DateTime.Now.AddDays(40));

            Console.WriteLine("****************************************************************");


            boardMember.EndOfYearOperation();
            salesPerson.EndOfYearOperation();
            employee.EndOfYearOperation();

            Console.WriteLine("****************************************************************");

            boardMember.Resign();
            salesPerson.CheckTarget(50);

        }
    }
}