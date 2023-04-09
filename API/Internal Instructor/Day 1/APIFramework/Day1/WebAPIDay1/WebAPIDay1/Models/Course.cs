using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDay1.Models
{
    public class Course
    {
        public int id { get; set; }
        public string name { get; set; }
        public int duration { get; set; }
        public string description{ get; set; }
    }
}