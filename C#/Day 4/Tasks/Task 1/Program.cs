using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Task_1
{
    internal partial class Program
    {
/*
1
Khaled
DBA
65321
2/2/2000
M
2
Ayman
guest
65321
2/1/2000
M
3
Taha
Developer
65321
1/2/2000
M
*/
        static void Main(string[] args)
        {
            EmployeeSearch employees = new EmployeeSearch(3);

            for (int i = 0; i < 3; i++)
            {
                employees[i] = ReadEmployee();
                Console.Clear();
            }

            Console.WriteLine("All Employees:");
            for (int i = 1; i < 4; i++)
            {
                Console.WriteLine(employees[i]);
            }

            Console.WriteLine("************************************************************************");

            Console.WriteLine("By Search:");
            
            Console.WriteLine("Hire Date = 2/2/2000:");
            Console.WriteLine($"\n{employees[new HireDate(2,2,2000)]}\n");
            
            Console.WriteLine("Name = Ayman:");
            Console.WriteLine($"\n{employees["Ayman"]}\n");
            
            Console.WriteLine("Name = Ali:");
            try
            {
                Console.WriteLine($"\n{employees["Ali"]}\n");
            }
            catch
            {
                Console.WriteLine("No employee with the given name!");
            }

        }

        static public Employee ReadEmployee()
        {
            Employee employee = new Employee();
            
            bool valid = false;
            while (!valid)
            {
                Console.Write("Enter employee id: ");
                int id; 
                
                if (!int.TryParse(Console.ReadLine(), out id)) Console.WriteLine("Invalid id!");
                else
                {
                    valid = true;
                    employee.Id = id;
                }
            }

            valid = false;
            while (!valid)
            {
                Console.Write("Enter employee name: ");

                Regex rx = new Regex(@"([A-Z]||[a-z]|| )*");

                string name = Console.ReadLine();

                if (rx.IsMatch(name)) 
                {
                    valid = true;
                    employee.Name = name;
                }
                else
                    Console.WriteLine("Invalid id!");
            }

            valid = false;
            while (!valid)
            {
                Console.Write("Enter employee security level\n[guest, Developer, secretary, DBA, securityOfficer]: ");
                
                SecurityLevel securityLevel;
                
                if (!Enum.TryParse(Console.ReadLine(), out securityLevel)) Console.WriteLine("Invalid security level!");
                else
                {
                    valid = true;
                    employee.SecurityLevel = securityLevel;
                }
            }

            valid = false;
            while (!valid)
            {
                Console.Write("Enter employee salary: ");

                decimal salary;

                if (!decimal.TryParse(Console.ReadLine(), out salary) || salary == 0) Console.WriteLine("Invalid salary!");
                else
                {
                    valid = true;
                    employee.Salary = salary;
                }
            }

            valid = false;
            while (!valid)
            {
                Console.Write("Enter employee hire date\n[d/m/y]: ");

                string hiredate = Console.ReadLine();
                string[] parts = hiredate.Split('/');
                

                if (parts.Length == 3)
                {
                    int day, month, year;

                    if (int.TryParse(parts[0], out day) && int.TryParse(parts[1], out month) && int.TryParse(parts[2], out year))
                    {
                        if (day > 0 && day < 31 && month > 0 && month < 13 && year > 1930 && year < 2024)
                        {
                            valid = true;
                            employee.HireDate = new HireDate(day, month, year);
                        }
                    }
                    else Console.WriteLine("Invalid hire date!");
                }
                else Console.WriteLine("Invalid hire date!");
            }

            valid = false;
            while (!valid)
            {
                Console.Write("Enter employee gender\n[M, F]: ");

                Gender gender;

                if (!Enum.TryParse(Console.ReadLine(), out gender)) Console.WriteLine("Invalid gender!");
                else { 
                    valid = true;
                    employee.Gender = gender;
                }
            }

            return employee;
        }
    }
}