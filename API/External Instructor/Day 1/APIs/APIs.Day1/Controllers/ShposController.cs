using APIs.Day1.Filters;
using APIs.Day1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APIs.Day1.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShposController : ControllerBase
{
    public static List<Shop> _shops = new();

    [HttpPost]
    [Route("v1")]
    public ActionResult Add(Shop shop)
    {
        shop.Id = new Random().Next(1, 1000);
        shop.Location = "EG";
        _shops.Add(shop);
        return Ok(new { NewItemId = shop.Id });
    }


    [HttpPost]
    [Route("v2")]
    [ServiceFilter(typeof(ValidateShopLocationAttribute))]
    public ActionResult AddV2(Shop shop)
    {
        shop.Id = new Random().Next(1, 1000);
        _shops.Add(shop);

        return Ok(new { NewItemId = shop.Id });
    }
}
