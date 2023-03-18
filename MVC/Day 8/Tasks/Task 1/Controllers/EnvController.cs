using Microsoft.AspNetCore.Mvc;

namespace Task_1.Controllers
{
    public class EnvController : Controller
    {
        private readonly IWebHostEnvironment environment;
        
        public EnvController(IWebHostEnvironment env)
        {
            environment = env;
        }

        public string Index()
        {
            return $"{environment.ApplicationName}\n{environment.EnvironmentName}";
        }
    }
}
