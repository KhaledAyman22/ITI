using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRDemo.Hubs;
using SignalRDemo.Models;

namespace SignalRDemo.Controllers
{
    public class EmployeeController : Controller
    {
        List<Employee> _employees;
        private readonly IHubContext<EmployeeHub> empHub;

        public EmployeeController(IHubContext<EmployeeHub> empHub)//ask inject service obj
        {
            this.empHub = empHub;
            _employees =new List<Employee>();
            _employees.Add(new Employee() { Id=1,Name="Ahme",Salary=8000});
            _employees.Add(new Employee() { Id = 2, Name = "Alaa", Salary = 8000 });
            _employees.Add(new Employee() { Id = 3, Name = "Amira", Salary = 8000 });
        }
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult ShowAll()
        {
            return View(_employees);
        }
        [HttpGet]
        public IActionResult Insert()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Insert(Employee newEmp)
        {
            _employees.Add(newEmp);
            //call hub outside hub context
            empHub.Clients.All.SendAsync("NotifyNewEmployee", newEmp);
            return View();
        }

    }
}
