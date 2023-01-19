using System.Drawing;

namespace Task_1
{
    internal partial class Program
    {
        public struct Employee
        {
            public int Id{get; set;}
            public string Name { get; set; }
            public SecurityLevel SecurityLevel{get; set;}
            public decimal Salary{get; set;}
            public HireDate HireDate{get; set;}
            public Gender Gender { get; set;}

            public Employee(int id, SecurityLevel security_level, decimal salary, HireDate hire_date, Gender gender)
            {
                Id = id;
                SecurityLevel = security_level;
                Salary = salary;
                HireDate = hire_date;
                Gender  = gender;
            }

            public override string ToString()
            {
                return $"ID: {Id}\n" +
                    $"Name: {Name}\n" +
                    $"Gender: {Gender}\n" +
                    $"SecurityLevel: {SecurityLevel}\n" +
                    $"Salary: {string.Format("{0:C}", Salary)}\n" +
                    $"Hire Date: {HireDate}\n";
            }
        }
    }
}