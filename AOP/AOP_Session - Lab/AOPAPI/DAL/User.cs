using System.Collections.Generic;

namespace AOPAPI.DAL
{
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public virtual List<UserCourse> UserCourses { get; set; }
    }
}
