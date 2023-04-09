using Day01.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Text.RegularExpressions;

namespace Day01.Validators
{
    public class CarTypeAttribute: ActionFilterAttribute
    {
        private readonly ILogger<CarTypeAttribute> _logger;

        public CarTypeAttribute(ILogger<CarTypeAttribute> logger)
        {
            _logger = logger;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var regex = new Regex("^(Gas|Hybrid|Diesel|Electric)$",
                RegexOptions.IgnoreCase,
                TimeSpan.FromSeconds(2));

            if (context.ActionArguments["car"] is not Car car || !regex.IsMatch(car.Type))
            {
                context.ModelState.AddModelError("Type", "Type is unsupported.");
                context.Result = new BadRequestObjectResult(context.ModelState);
            }
        }
    }
}
