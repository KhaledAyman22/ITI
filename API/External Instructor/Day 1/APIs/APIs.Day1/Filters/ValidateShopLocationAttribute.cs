using APIs.Day1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;

namespace APIs.Day1.Filters;

public class ValidateShopLocationAttribute : ActionFilterAttribute
{
    private readonly ILogger<ValidateShopLocationAttribute> _logger;
    private readonly IConfiguration _configuration;

    public ValidateShopLocationAttribute(
        ILogger<ValidateShopLocationAttribute> logger,
        IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        _logger.LogWarning("Filter execution started");
        var allowed = _configuration.GetValue<string>("AllowedLocations");
        Shop? shop = context.ActionArguments["shop"] as Shop;

        var regex = new Regex("^(EG|USA|UAE)$",
            RegexOptions.IgnoreCase,
            TimeSpan.FromSeconds(2));

        if (shop is null || !regex.IsMatch(shop.Location))
        {
            //Short Circuit with BadRequest
            context.ModelState.AddModelError("Location", "Location is not covered");
            context.Result = new BadRequestObjectResult(context.ModelState);
        }
    }
}
