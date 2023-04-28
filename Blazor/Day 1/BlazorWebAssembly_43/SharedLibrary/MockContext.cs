using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedLibrary
{
    public class MockContext
    {
        public static List<Country> Countries = new List<Country>
            {
                new Country {CountryId = 1, Name = "Egypt"},
                new Country {CountryId = 2, Name = "USA"},
                new Country { CountryId = 3, Name = "Japan" },
                new Country { CountryId = 4, Name = "France" },
                new Country { CountryId = 5, Name = "Brazil" }
            };

        public static List<Employee> Employees = new List<Employee>()
        {
            new Employee
            {
                CountryId = 1,
                MaritalStatus = MaritalStatus.Single,
                BirthDate = new DateTime(1989, 3, 11),
                Email = "basma@test.com",
                EmployeeId = 1,
                FirstName = "Basma",
                LastName = "Hussien",
                Gender = Gender.Female,
                PhoneNumber = "01000101010",
                Comment = "Hello there....",
                ExitDate = null,
                JoinedDate = new DateTime(2008, 3, 1)
            },

            new Employee
            {
                CountryId = 2,
                MaritalStatus = MaritalStatus.Married,
                BirthDate = new DateTime(1989, 3, 11),
                Email = "Mohamed@test.com",
                EmployeeId = 2,
                FirstName = "Mohamed",
                LastName = "Ahmed",
                Gender = Gender.Male,
                PhoneNumber = "01000101010",
                Comment = "Hello there222....",
                ExitDate = null,
                JoinedDate = new DateTime(2009, 7, 1)
            }
        };
    }
}