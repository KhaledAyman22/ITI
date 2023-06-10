using System.Collections.Generic;

namespace AOPAPI.DAL.Repositories
{
    public interface ICourseRepository
    {
        bool Delete(int courseId);
        IEnumerable<Course> GetAll();
        Course GetById(int id);
    }
}