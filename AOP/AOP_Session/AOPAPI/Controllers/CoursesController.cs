using AOPAPI.BLL;
using AOPAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AOPAPI.Controllers
{
    [RoutePrefix("api/Courses")]
    public class CoursesController : ApiController
    {
        private readonly ICourseService _courseService;

        public CoursesController(ICourseService courseService)
        {
            _courseService = courseService;
        }

        [Route()]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = _courseService.GetAll();
            return Ok(users);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetUsers(int id)
        {
            var users = _courseService.GetById(id);
            return Ok(users);
        }

        [Route("{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var input = new DeleteCourseInput() { CourseId = id };
            var users = _courseService.Delete(input);
            return Ok(users);
        }
    }
}
