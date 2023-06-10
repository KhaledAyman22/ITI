using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            var users = _context.Users;
            return users;
        }

        public User GetById(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.ID == id);
            return user;
        }

        public bool AssignCourse(User user, Course course)
        {
            var userCourse = new UserCourse() { UserId = user.ID, CourseId = course.ID, User = user, Course = course };
            user.UserCourses.Add(userCourse);
            course.UserCourses.Add(userCourse);
            return true;
        }

    }
}