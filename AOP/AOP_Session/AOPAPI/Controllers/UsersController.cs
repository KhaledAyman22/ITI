using AOPAPI.BLL;
using AOPAPI.Models;
using System.Web.Http;

namespace AOPAPI.Controllers
{
    [RoutePrefix("api/Users")]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [Route()]
        [HttpGet]
        public IHttpActionResult GetUsers()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [Route("{id:int}")]
        [HttpGet]
        public IHttpActionResult GetUsers(int id)
        {
            var users = _userService.GetById(id);
            return Ok(users);
        }

        [Route("Assign")]
        [HttpPost]
        public IHttpActionResult Assign(AssignCourseInput input)
        {
            var users = _userService.AssignCourse(input);
            return Ok(users);
        }
    }
}
