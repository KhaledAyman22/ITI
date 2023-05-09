using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Entities
{
    public class Owner
    {
        public int Id { get; }

        public string Name { get; set; }
        public Car Car { get; set; }
        public Owner()
        {

        }
        public Owner(int id,string name)
        {
            Id = id;
            Name = name;
        }
    }
}