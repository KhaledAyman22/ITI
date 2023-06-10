using AOPAPI.DAL;
using AOPAPI.Models;
using System.Collections.Generic;

namespace AOPAPI.BLL
{
    public interface IUserService
    {
        bool AssignCourse(AssignCourseInput input);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
