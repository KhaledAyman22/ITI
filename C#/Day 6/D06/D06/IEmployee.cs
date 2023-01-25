using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D06
{
    interface IEmployee
    {
        public int Id { get; init; } 
        public string Name { get; init; }
        public decimal Salary { get; init; }
        void Promote();
    }


    struct Employee : IEmployee
    {
        int id;
        public int Id { get => id; init => id = value; }
        string name;
        public string Name { get => name; init => name = value; }

        public decimal Salary { get => salary; init => salary = value; }

        decimal salary;

        public override string ToString()
        {
            return $"{id} , {name} , {salary}";
        }

        public void Promote()
        {
            salary += 1000;
        }
    }


}
