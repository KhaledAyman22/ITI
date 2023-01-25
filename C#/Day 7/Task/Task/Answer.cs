using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task
{
    internal class Answer
    {
        public string Statment { get; set; }

        public Answer(string statment)
        {
            Statment = statment;
        }

        public override string ToString()
        {
            return $"{Statment}";
        }

        public override bool Equals(object? obj)
        {
            if(obj == null) return false;
            if(obj is not Answer) return false;
            if (obj == this) return true;


            return Statment == ((Answer)(obj)).Statment;
        }
    }
}
