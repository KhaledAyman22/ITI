using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_PII
{
    public class ExceedingBalanceEventArgs:EventArgs
    {
        public decimal DiffAmount { get; set; }
        public DateTime TransactionTime { get; } = DateTime.Now;
    }
}
