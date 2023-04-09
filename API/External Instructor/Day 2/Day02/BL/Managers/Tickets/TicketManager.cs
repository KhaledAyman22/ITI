using BL.Dtos.Ticket;
using DAL.Models;
using DAL.Repos.Developers;
using DAL.Repos.Tickets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Managers.Tickets
{
    public class TicketManager : ITicketManager
    {
        private readonly ITicketRepo _ticketRepo;
        private readonly IDeveloperRepo _developerRepo;

        public TicketManager(ITicketRepo ticketRepo, IDeveloperRepo developerRepo)
        {
            _ticketRepo = ticketRepo;
            _developerRepo = developerRepo;
        }

        public int CreateTicket(CreateTicketDto ticket)
        {
            var tmp = new Ticket()
            {
                Name = ticket.Name,
                DepartmentId = ticket.DepartmentId
            };

            _ticketRepo.CreateTicket(tmp);

            _ticketRepo.SaveChanges();
            return tmp.Id;
        }

        public int DeleteTicket(int id)
        {
            _ticketRepo.DeleteTicket(id);
            return _ticketRepo.SaveChanges();
        }

        public ReadTicketDto? ReadTicket(int id)
        {
            var ticket = _ticketRepo.ReadTicket(id);

            if (ticket is null) return null;

            return new(ticket.Id, ticket.Name, ticket.DepartmentId);
        }

        public IEnumerable<ReadTicketDto> ReadTickets()
        {
            return _ticketRepo.ReadTickets().Select(t => new ReadTicketDto(t.Id, t.Name, t.DepartmentId));
        }

        public int UpdateTicket(UpdateTicketDto ticket)
        {
            _ticketRepo.UpdateTicket(new()
            {
                Id = ticket.Id,
                Name = ticket.Name,
                DepartmentId = ticket.DepartmentId
            });

            return _ticketRepo.SaveChanges();
        }

        public int UpdateTicketWithDevelopers(UpdateTicketWithDevelopersDto ticket)
        {
            _ticketRepo.UpdateTicketWithDevelopers(new()
            {
                Id = ticket.Id,
                Name = ticket.Name,
                DepartmentId = ticket.DepartmentId,
                Developers = _developerRepo.GetDevelopersByIds(ticket.DeveloperIds)
            });

            return _ticketRepo.SaveChanges();
        }
    }
}
