using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompanyConsoleAPP.Entities
{
    public class Client
    {
        public int CID { get; set; }

        public string FName { get; set; }
        public string LName { get; set; }
        public string MName { get; set; }

        public DateTime TimeStamp { get; } = DateTime.Now;

        public decimal Deposit { get; set; }

        public virtual ICollection<Branch> Branches { get; set; } = new HashSet<Branch>();
        public virtual ICollection<EmployeeClient> EmployeeClients { get; set; } = new HashSet<EmployeeClient>();

    }
}
