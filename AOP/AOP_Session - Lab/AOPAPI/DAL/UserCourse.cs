using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.DAL
{
    public class UserCourse
    {
        public int UserId { get; set; }
        public int CourseId { get; set; }
        public virtual User User { get; set; }
        public virtual Course Course { get; set; }
    }
}