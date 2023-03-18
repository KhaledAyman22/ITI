using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDay1.Models;

namespace WebAPIDay1.Controllers
{
    public class CourseController : ApiController
    {
        public static List<Course> courses = new List<Course>()
        {
            new Course(){id=1 , name="CSharp" , duration =60 , description="intro to .net and C# Basics"},
            new Course(){id=2 , name="SQL" , duration =50 , description="Structure Query Languge"},
            new Course(){id=3 , name="ASPDotNet" , duration =36 , description="Server Side Programming"},
            new Course(){id=4 , name="MVC" , duration =30 , description="Server side Programming"}
        };
        public IHttpActionResult get()
        {
            if(courses == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(courses);
            }
        }
        public IHttpActionResult deleteCourse(int id)
        {
            var crs = courses.FirstOrDefault(c => c.id == id);
            if(crs == null)
            {
                return NotFound();
            }
            else
            {
                courses.Remove(crs);
                return Ok(courses);
            }
        }
        public IHttpActionResult put([FromUri]int id,[FromBody]Course course)
        {
            if(id != course.id)
            {
                return NotFound();
            }
            var crs = courses.FirstOrDefault(c => c.id == id);
            if(crs == null)
            {
                return NotFound();
            }
            crs.id = course.id;
            crs.name = course.name;
            crs.duration = course.duration;
            crs.description = course.description;

            return StatusCode(HttpStatusCode.NoContent);

        }
        public IHttpActionResult post(Course course)
        {
            if(course == null)
            {
                return BadRequest();
            }
            else
            {
                courses.Add(course);
                return Created("created at list of Cources", courses);
            }
        }
        public IHttpActionResult getById(int id)
        {
            var crs = courses.FirstOrDefault(c => c.id == id);
            if(crs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(crs);
            }
        }
        [HttpGet]
        [Route("api/Course/{name:alpha}")]
        public IHttpActionResult courseByName(string name)
        {
            var crs = courses.FirstOrDefault(c => c.name == name);
            if(crs == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(crs);
            }
        }


    }
}
