using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_PII
{
    internal class CreditCardBankAccount:BankAccount
    {
        public decimal Limit { get; set; }

        protected override void OnExceedingBalance(ExceedingBalanceEventArgs e)
        {
            ///Attach new Statments before notify Subsc.

            ///Control Base event invocation Business Rules
            if (e.DiffAmount > Limit)
                base.OnExceedingBalance(e);
        }
    }
}
