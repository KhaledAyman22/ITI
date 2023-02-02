using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D10
{
    internal class Employee
    {
        public int ID { get; init; }
        public string Name { get; init; }
        public decimal Salary { get; init; }
        public Department Department { get; set; }

        public override bool Equals(object? obj)
        {
            if ((obj is Employee R) && (R != null) && (R.GetType() == this.GetType()))
            {
                if (object.ReferenceEquals(this, R)) return true;
                return ID == R.ID && Name == R.Name && Salary == R.Salary;
            }

            return false;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ID, Name, Salary);
        }

        public override string ToString() =>
            $"ID: {ID} , Name : {Name} , Salary : {Salary} , Dept : {Department.Title}";
    }


    class Department
    {
        public int ID { get; set; }
        public string Title { get; set; }

    }
}
