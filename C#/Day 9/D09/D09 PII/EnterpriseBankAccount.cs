using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_PII
{
    internal class EnterpriseBankAccount : BankAccount
    {
        public string CompanyName { get; set; }

        public bool TransferSalary (decimal Amount, BankAccount DestBankAccount)
        {
            if ((Amount > 0) && (Amount <= Balance))
            {
                Balance -= Amount;
                DestBankAccount.Balance += Amount;
                return true;
            }
            else
                ///Notify Subsc.for Base Event
                //ExceedingBalance.Invoke(this, new ExceedingBalanceEventArgs() { DiffAmount = Amount - Balance });
                ///Not Valid in C# to Invoke Base event

                ///Only Valid way to invoke base event , through Base.OnEventName()
                OnExceedingBalance(new() { DiffAmount = Amount - Balance });
            
            return false;
        }
    }
}
