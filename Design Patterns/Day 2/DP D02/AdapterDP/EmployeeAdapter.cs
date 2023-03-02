using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterDP
{
    internal class EmployeeAdapter : Person
    {
        Employee employee;

        public EmployeeAdapter(Employee E)=> employee = E;

        public string ID 
        { get => employee.Id.ToString(); 
            set 
            {
                if (int.TryParse(value, out int TempInt))
                    employee.Id = TempInt;
                else
                    employee.Id = -1;
            } 
        }
        ///Delegation
        public string FullName 
        { 
            get => $"{employee.FName} {employee.LName}"; 
            set => throw new NotImplementedException(); 
        }
        public string AnnualAlary
        {
            get => $"{employee.MonthlySalary * 12}"; 
            set
            {
                if (decimal.TryParse(value, out decimal ASal))
                    employee.MonthlySalary = ASal / 12.0M;
                else
                    employee.MonthlySalary = 2700;
            }
        }
    }
}
