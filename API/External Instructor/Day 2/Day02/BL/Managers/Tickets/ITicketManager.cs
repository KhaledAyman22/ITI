using BL.Dtos.Ticket;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Tickets
{
    public interface ITicketManager
    {
        public int CreateTicket(CreateTicketDto ticket);
        public ReadTicketDto? ReadTicket(int id);
        public IEnumerable<ReadTicketDto> ReadTickets();
        public int UpdateTicket(UpdateTicketDto ticket);
        public int UpdateTicketWithDevelopers(UpdateTicketWithDevelopersDto ticket);
        public int DeleteTicket(int id);
    }
}
