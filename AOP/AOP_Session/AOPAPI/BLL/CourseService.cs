using AOPAPI.DAL;
using AOPAPI.DAL.Repositories;
using AOPAPI.Models;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AOPAPI.BLL
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;

        public CourseService(
            ICourseRepository courseRepository
            )
        {
            _courseRepository = courseRepository;
        }
        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll();
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetById(id);
        }

        public bool Delete(DeleteCourseInput input)
        {
            return _courseRepository.Delete(input.CourseId);
        }

        //public bool IsValid(DeleteCourseInput input)
        //{
        //    var course = _courseRepository.GetById(input.CourseId);
        //    return course != null;
        //}
    }
}