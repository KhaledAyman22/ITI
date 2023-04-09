using BL.Dtos.Ticket;
using BL.Managers.Tickets;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Day02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketsController : ControllerBase
    {
        private readonly ITicketManager _ticketManager;

        public TicketsController(ITicketManager ticketManager)
        {
            _ticketManager = ticketManager;
        }

        // GET: api/<TicketsController>
        [HttpGet]
        public ActionResult<IEnumerable<ReadTicketDto>> Get()
        {
            return Ok(_ticketManager.ReadTickets());
        }

        // GET api/<TicketsController>/5
        [HttpGet("{id}")]
        public ActionResult<ReadTicketDto> Get(int id)
        {
            var ticket = _ticketManager.ReadTicket(id);
            if(ticket is null) return NotFound();
            return Ok(ticket);
        }

        // POST api/<TicketsController>
        [HttpPost]
        public ActionResult Post([FromBody] CreateTicketDto ticket)
        {
            int id = _ticketManager.CreateTicket(ticket);

            return CreatedAtAction(
                    actionName: nameof(Get),
                    routeValues: new { id },
                    value: new { Message = "The ticket has been added successfully." }
                );
        }

        // PUT api/<TicketsController>/5
        [HttpPut]
        public ActionResult Put([FromBody] UpdateTicketDto ticket)
        {
            int res = _ticketManager.UpdateTicket(ticket);

            return res == 0 ? NotFound() : NoContent();
        }

        // PUT api/<TicketsController>/5
        [HttpPut("withdevs")]
        public ActionResult PutWithDevs([FromBody] UpdateTicketWithDevelopersDto ticket)
        {
            int res = _ticketManager.UpdateTicketWithDevelopers(ticket);

            return res == 0 ? NotFound() : NoContent();
        }

        // DELETE api/<TicketsController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            int res = _ticketManager.DeleteTicket(id);

            return res == 0 ? NotFound() : NoContent();
        }
    }
}
