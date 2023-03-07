using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirstMVCApp_43.Models
{
    public class EmployeeList
    {
       public static List<Employee> Employees = new List<Employee>()
       { 
            new Employee() { ID = 1, Name = "test_1", Age = 11, Email = "test_1@company.com" },
            new Employee() { ID = 2, Name = "ahmed", Age = 22, Email = "test_1@company.com" },
            new Employee() { ID = 3, Name = "mohamed", Age = 33, Email = "test_1@company.com" },
            new Employee() { ID = 4, Name = "mona", Age = 44, Email = "test_1@company.com" },
            new Employee() { ID = 5, Name = "soha", Age = 55, Email = "test_1@company.com" }
       };
    }
}