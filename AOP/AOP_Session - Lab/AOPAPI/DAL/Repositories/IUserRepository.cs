using System.Collections.Generic;

namespace AOPAPI.DAL.Repositories
{
    public interface IUserRepository
    {
        bool AssignCourse(User user, Course course);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}