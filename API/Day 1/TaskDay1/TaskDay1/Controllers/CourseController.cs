using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;
using System;
using TaskDay1.Models;

namespace TaskDay1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : Controller
    {
        [HttpGet]
        public IActionResult Get()
        {
            if (Course.Courses.Any()) return Ok(Course.Courses);

            return NotFound();
        }

        [HttpDelete]
        public IActionResult DeleteCourse(int id)
        {
            var c = Course.Courses.Where(c => c.Id == id).FirstOrDefault();
            if (c == null) return NotFound();

            Course.Courses.Remove(c);
            return Ok(Course.Courses);
        }

        [HttpPut]
        public IActionResult Put(int id, Course course)
        {
            if(id != course.Id) return BadRequest();
            
            var c = Course.Courses.Where(c => c.Id == id).FirstOrDefault();

            if(c == null) return NotFound();

            Course.Courses.Remove(c);
            Course.Courses.Add(course);
            return NoContent();
        }

        [HttpPost]
        public IActionResult Post(Course course) 
        { 
            var c = Course.Courses.Where(c => c.Id == course.Id).FirstOrDefault();
            if(course == null || c != null) return BadRequest();

            Course.Courses.Add(course);
            return Created($"/GetById/{course.Id}", course);
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            var c = Course.Courses.Where(c => c.Id == id).FirstOrDefault();
            if (c == null) return NotFound();
            return Ok(c);
        }

        [HttpGet("{name:alpha}")]
        public IActionResult CourseByName(string name)
        {
            var c = Course.Courses.Where(c => c.Name == name).FirstOrDefault();
            if (c == null) return NotFound();
            return Ok(c);
        }
    }
}
