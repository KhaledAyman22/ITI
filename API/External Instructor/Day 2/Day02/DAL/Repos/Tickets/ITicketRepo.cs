using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos.Tickets
{
    public interface ITicketRepo
    {
        public int CreateTicket(Ticket ticket);
        public Ticket? ReadTicket(int id);
        public ICollection<Ticket> ReadTickets();
        public void UpdateTicket(Ticket ticket);
        public void DeleteTicket(int id);
        public void UpdateTicketWithDevelopers(Ticket ticket);
        public int SaveChanges();
    }
}
