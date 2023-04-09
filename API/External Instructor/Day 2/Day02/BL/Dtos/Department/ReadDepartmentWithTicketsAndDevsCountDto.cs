using BL.Dtos.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.Dtos.Department
{
    public record ReadDepartmentWithTicketsAndDevsCountDto
    (int Id,
    string Name,
    IEnumerable<DepartmentChildTicketDto> Tickets);
}
