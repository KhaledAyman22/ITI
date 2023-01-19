using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Task_1
{
    internal partial class Program
    {
        public class EmployeeSearch
        {
            private Employee[] employees;

            public Employee this[int id]
            {
                set { 
                    if(id<employees.Length)    
                        employees[id] = value; 
                }

                get
                {
                    for (int i = 0; i < employees.Length; i++)
                        if (employees[i].Id == id)
                            return employees[i];

                    throw new IndexOutOfRangeException();
                }
            }

            public Employee this[HireDate date]
            {
                get
                {
                    for (int i = 0; i < employees.Length; i++)
                        if (employees[i].HireDate.Equals(date))
                            return employees[i];

                    throw new IndexOutOfRangeException();
                }
            }

            public Employee this[string name]
            {
                get
                {
                    for (int i = 0; i < employees.Length; i++)
                        if (employees[i].Name == name)
                            return employees[i];

                    throw new IndexOutOfRangeException();
                }
            }


            public EmployeeSearch(int size)
            {
                employees = new Employee[size];
            }
        }
    }
}
