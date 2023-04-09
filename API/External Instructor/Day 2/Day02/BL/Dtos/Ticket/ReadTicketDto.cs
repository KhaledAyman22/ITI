using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Ticket
{
    public record ReadTicketDto (int Id, string Name, int DepartmentId);
}
