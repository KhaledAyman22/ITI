using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(string requestType, string requestBody, int? id)
        {
            ResponseViewModel model = new();

            switch (requestType)
            {
                case "GetBranches": model =  await RequestHelper.GetBranchesBtn(); break;
                case "GetBranch": model =  await RequestHelper.GetBranchBtn(id??0); break;
                case "PutBranch": model =  await RequestHelper.PutBranchBtn(requestBody); break;
                case "PostBranch": model =  await RequestHelper.PostBranchBtn(requestBody); break;
                case "DeleteBranch": model =  await RequestHelper.DeleteBranchBtn(id??0); break;
                case "GetDepartments": model =  await RequestHelper.GetDepartmentsBtn(); break;
                case "GetDepartmentsDetailed": model =  await RequestHelper.GetDepartmentsDetailedBtn(); break;
                case "GetDepartment": model =  await RequestHelper.GetDepartmentBtn(id ?? 0); break;
                case "GetDepartmentDetailed": model =  await RequestHelper.GetDepartmentDetailedBtn(id ?? 0); break;
                case "PutDepartment": model =  await RequestHelper.PutDepartmentBtn(requestBody); break;
                case "PostDepartment": model =  await RequestHelper.PostDepartmentBtn(requestBody); break;
                case "DeleteDepartment": model =  await RequestHelper.DeleteDepartmentBtn(id ?? 0); break;
                case "GetInstructors": model =  await RequestHelper.GetInstructorsBtn(); break;
                case "GetInstructor": model =  await RequestHelper.GetInstructorBtn(id ?? 0); break;
                case "PutInstructor": model =  await RequestHelper.PutInstructorBtn(requestBody); break;
                case "PostInstructor": model =  await RequestHelper.PostInstructorBtn(requestBody); break;
                case "DeleteInstructor": model =  await RequestHelper.DeleteInstructorBtn(id ?? 0); break;
            }

            return View(model);
        }


    }
}