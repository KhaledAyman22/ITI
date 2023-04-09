using Day01.Models;
using Day01.Validators;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day01.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        static Random random = new Random();
        private readonly ILogger<CarsController> _logger;

        public CarsController(ILogger<CarsController> logger)
        {
            _logger = logger;
        }


        // GET: api/<CarsController>
        [HttpGet("requests")]
        public ActionResult<int> GetRequests()
        {
            return Ok(Car.Requests);
        }

        // GET: api/<CarsController>
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            _logger.LogCritical("Get is called!!");
            if(Car.Cars.Count == 0)
            {
                return NotFound("No objects in the list");
            }

            return Ok(Car.Cars);
        }

        // GET api/<CarsController>/5
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car? car = Car.Cars.Find(x => x.Id == id);
            return car is null ? NotFound() : Ok(car);
        }

        // POST api/<CarsController>
        [HttpPost()]
        public ActionResult Post([FromBody] Car car)
        {
            car.Id = random.Next(20, 100);
            car.Type = "Gas";
            Car.Cars.Add(car);

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = car.Id },
                value: new { Message = "The car has been added successfully." });
        }

        // POST api/<CarsController>
        [HttpPost("v2")]
        [ServiceFilter(typeof(CarTypeAttribute))]
        public ActionResult PostV2([FromBody] Car car)
        {
            car.Id = random.Next(20, 100);
            Car.Cars.Add(car);

            return CreatedAtAction(
                actionName: nameof(Get),
                routeValues: new { id = car.Id },
                value: new { Message = "The car has been added successfully." });
        }

        // PUT api/<CarsController>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Car car)
        {
            if (id != car.Id)
            {
                return BadRequest();
            }

            Car? _car = Car.Cars.Find(m => m.Id == id);
            
            if (_car is null) return NotFound();

            _car.Make = car.Make;
            _car.Model = car.Model;
            _car.ProductionDate = car.ProductionDate;

            return NoContent();
        }

        // DELETE api/<CarsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            Car? car = Car.Cars.Find(m => m.Id == id);
            if (car is null) return NotFound();

            Car.Cars.Remove(car);

            return NoContent();
        }
    }
}
