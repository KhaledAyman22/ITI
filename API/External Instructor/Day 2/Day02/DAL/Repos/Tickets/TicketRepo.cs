using DAL.Context;
using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Tickets
{
    public class TicketRepo : ITicketRepo
    {
        private readonly APIDay02Context _context;

        public TicketRepo(APIDay02Context context)
        {
            _context = context;
        }

        public int CreateTicket(Ticket ticket)
        {
            _context.Add(ticket);
            return ticket.Id;
        }

        public void DeleteTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);

            if (ticket is null) return;

            _context.Remove(ticket);
        }

        public Ticket? ReadTicket(int id)
        {
            var ticket = _context.Tickets.Find(id);

            if (ticket is null) return null;

            return ticket;
        }

        public ICollection<Ticket> ReadTickets()
        {
            return _context.Tickets.AsNoTracking().ToList();
        }

        public void UpdateTicket(Ticket ticket)
        {
            var _ticket = _context.Tickets.Find(ticket.Id);

            if (_ticket is null) return;

            _ticket.Name = ticket.Name;
            _ticket.DepartmentId = ticket.DepartmentId;
        }
                
        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void UpdateTicketWithDevelopers(Ticket ticket)
        {
            var _ticket = _context.Tickets.Find(ticket.Id);

            if (_ticket is null) return;

            _context.Entry(_ticket).Collection(p => p.Developers).Load();
            _ticket.Name = ticket.Name;
            _ticket.DepartmentId = ticket.DepartmentId;
            _ticket.Developers.Clear();

            foreach (var dev in ticket.Developers)
                _ticket.Developers.Add(dev);

            //Can I just start tracking the new object??
            //_context.Update(ticket);
        }
    }
}
