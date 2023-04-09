using BL.Dtos.Department;
using BL.Managers.Departments;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentManager _departmentManager;

        public DepartmentsController(IDepartmentManager departmentManager)
        {
            _departmentManager = departmentManager;
        }

        [HttpGet]
        public ActionResult<ReadDepartmentWithTicketsAndDevsCountDto> GetDepartmentDetailed(int id)
        {
            var dep = _departmentManager.GetDepartmentWithTicketsAndDevCount(id);

            return dep is null? NotFound() : Ok(dep);
        }
    }
}
