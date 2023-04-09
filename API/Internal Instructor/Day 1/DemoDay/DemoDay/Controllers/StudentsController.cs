using DemoDay.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace DemoDay.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        //[HttpGet]
        //public List<Student> get()
        //{
        //    return StudentList.students.ToList();
        //}
        //[HttpGet("{id:int}")]
        //public Student getById(int id)
        //{
        //    Student std = StudentList.students.Find(s=>s.Id == id);
        //    return std;
        //}
        //[HttpGet("{name:alpha}")]
        //public Student getByName(string name)
        //{
        //    Student std = StudentList.students.Find(s => s.Name.ToLower() == name.ToLower());
        //    return std;
        //}
        //[HttpPost]
        //public List<Student> addStd(Student s) 
        //{
        //    StudentList.students.Add(s);
        //    return StudentList.students.ToList();
        //}
        //[HttpDelete]
        //public List<Student> deleteStd(int id)
        //{
        //    Student std = StudentList.students.Find(s=>s.Id == id);
        //    StudentList.students.Remove(std);
        //    return StudentList.students.ToList();
        //}
        //[HttpPut]
        //public List<Student>  Maha(int id, Student s)
        //{
        //    Student std = StudentList.students.Find(s => s.Id == id);
        //    std.Id = s.Id; std.Name = s.Name;

        //    return StudentList.students.ToList();
        //}

        //api 1
        //[HttpGet]
        //[Route("GetAllStds")]
        //public HttpResponseMessage getAll()
        //{
        //    List<Student> students = StudentList.students.ToList();
        //    var res = new { massage = "OK", Std = students };
        //    if(students.Count == 0)
        //    {
        //        return new HttpResponseMessage() { StatusCode=HttpStatusCode.NotFound};
        //    }
        //    return new HttpResponseMessage() { StatusCode = HttpStatusCode.OK,ReasonPhrase=JsonSerializer.Serialize(res), Content = new StringContent(students.ToString(),System.Text.Encoding.UTF8,"Application/json") };
        //}
        [HttpGet]
        public IActionResult getAll()
        {
            List<Student> stds = StudentList.students.ToList();
            if (stds.Count == 0)
                return NotFound();
            return Ok(stds);
        }
        [HttpGet("getall/{id}")]
        public IActionResult get(int id)
        {
            Student std = StudentList.students.Find(x => x.Id == id);   
            if(std == null) 
                return NotFound();
            return Ok(std);
        }

        public IActionResult delete(int id)
        {
            Student std = StudentList.students.Find(x => x.Id == id);
            if (std == null)
                return NotFound();
            StudentList.students.Remove(std);
            return Ok(std);
        }


    }
}
