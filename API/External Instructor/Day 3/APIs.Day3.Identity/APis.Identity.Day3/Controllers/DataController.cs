using APis.Identity.Day3.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace APis.Identity.Day3.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DataController : ControllerBase
{
    private readonly UserManager<Employee> _userManager;

    public DataController(UserManager<Employee> userManager)
    {
        _userManager = userManager;
    }

    [HttpGet]
    [Authorize]
    public ActionResult GetData()
    {
        return Ok(new { Data = "This data is secured" });
    }


    [HttpGet]
    [Route("Manager")]
    [Authorize(Policy = "AllowManagers")]
    public ActionResult GetDataForAdmins()
    {
        return Ok(new { Data = "This data is secured" });
    }

    [HttpGet]
    [Route("Engineer")]
    [Authorize(Policy = "AllowEngineers")]
    public async Task<ActionResult> GetDataForEngineers()
    {
        //var id = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        //var user = await _userManager.FindByIdAsync(id);

        var user = await _userManager.GetUserAsync(User);
        return Ok(new { Data = "This data is secured" });
    }
}
