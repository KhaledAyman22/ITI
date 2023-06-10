using AOPAPI.DAL;
using AOPAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.BLL
{
    public interface ICourseService
    {
        bool Delete(DeleteCourseInput input);
        IEnumerable<Course> GetAll();
        Course GetById(int id);
    }
}