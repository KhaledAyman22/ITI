using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Subject
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public Subject(string name, string description)
        {
            Name = name;
            Description = description;
        }

        public override string ToString()
        {
            return $"Subject name: {Name}, description: {Description}";
        }

        public override bool Equals(object? obj)
        {
            if (obj == null) return false;
            if(obj is not Subject) return false;
            if (obj == this) return true;
            Subject s = (Subject)obj;
            return s.Name == Name && s.Description == Description;
        }
    }
}
