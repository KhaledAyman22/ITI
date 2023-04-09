using APIs.Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Day1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MobilesController : ControllerBase
{
    private readonly ILogger<MobilesController> _logger;
    private readonly IConfiguration _configuration;

    public MobilesController(ILogger<MobilesController> logger
        , IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [HttpGet]
    public ActionResult<List<Mobile>> GetAll()
    {
        _logger.LogCritical("Test");
        return Mobile.Mobiles; // return 200 
    }

    //api/Mobiles/id
    [HttpGet]
    [Route("{id}")]
    public ActionResult<Mobile> GetById(int id)
    {
        Mobile? mobile = Mobile.Mobiles.FirstOrDefault(m => m.Id == id);
        if (mobile is null)
        {
            return NotFound();
        }

        return mobile; // return 200 
    }

    //201 => Created
    [HttpPost]
    public ActionResult Add(Mobile mobile)
    {
        mobile.Id = new Random().Next(10, 1000);
        Mobile.Mobiles.Add(mobile);
        return CreatedAtAction(
            actionName: nameof(GetById),
            routeValues: new { id = mobile.Id },
            value: new { Message = "Mobile has been added successfully." });
    }

    [HttpPut]
    [Route("{id}")]
    public ActionResult Update(Mobile mobile, int id)
    {
        if (id != mobile.Id)
        {
            return BadRequest();
        }

        var mobileToUpdate = Mobile.Mobiles.FirstOrDefault(m => m.Id == id);
        if (mobileToUpdate is null)
        {
            return NotFound();
        }

        mobileToUpdate.Name = mobile.Name;
        mobileToUpdate.Price = mobile.Price;
        mobileToUpdate.Model = mobile.Model;

        return NoContent();
    }

    [HttpDelete]
    [Route("{id}")]
    public ActionResult DeleteById(int id)
    {

        var mobileToDelete = Mobile.Mobiles.FirstOrDefault(m => m.Id == id);
        if (mobileToDelete is null)
        {
            return NotFound();
        }

        Mobile.Mobiles.Remove(mobileToDelete);
        return NoContent();
    }
}
