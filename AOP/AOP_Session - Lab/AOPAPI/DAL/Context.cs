using System.Collections.Generic;

namespace AOPAPI.DAL
{
    public class Context
    {
        public List<User> Users { get; set; }
        public List<Course> Courses { get; set; }
        public List<UserCourse> UserCourses { get; set; }

        public Context()
        {
            GenerateEntities();
        }

        private void GenerateEntities()
        {
            var user1 = new User() { ID = 1, Age = 20, Name = "Ahmed", UserCourses = new List<UserCourse>() };
            var user2 = new User() { ID = 2, Age = 30, Name = "Yara", UserCourses = new List<UserCourse>() };
            var user3 = new User() { ID = 3, Age = 25, Name = "Mohamed", UserCourses = new List<UserCourse>() };

            var course1 = new Course() { ID = 1, Name = "OOP", Price = 100, UserCourses = new List<UserCourse>() };
            var course2 = new Course() { ID = 2, Name = "AOP", Price = 200, UserCourses = new List<UserCourse>() };

            var userCourse1 = new UserCourse() { CourseId = 1, UserId = 1, Course = course1, User = user1 };
            var userCourse2 = new UserCourse() { CourseId = 1, UserId = 2, Course = course1, User = user2 };
            var userCourse3 = new UserCourse() { CourseId = 1, UserId = 3, Course = course1, User = user3 };

            user1.UserCourses.Add(userCourse1);
            course1.UserCourses.Add(userCourse1);

            user2.UserCourses.Add(userCourse2);
            course1.UserCourses.Add(userCourse3);

            user3.UserCourses.Add(userCourse3);
            course1.UserCourses.Add(userCourse2);

            Users = new List<User>()
            {
                user1,user2,user3
            };

            Courses = new List<Course>()
            {
                course1,course2
            };

            UserCourses = new List<UserCourse>()
            {
                userCourse1,userCourse2,userCourse3
            };
        }
    }
}
