using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsoleAPP.Entities
{
    public class EmployeeClient
    {
        public int EmployeeEID { get; set; }
        public int ClientCID { get; set; }
        public DateTime Visit { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Client Client { get; set; }
    }
}
