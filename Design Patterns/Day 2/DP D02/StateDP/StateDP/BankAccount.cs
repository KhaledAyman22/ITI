using StateDP.Before_DP;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDP.StateDP
{
    /// <summary>
    /// Context
    /// </summary>
    internal class BankAccount
    {
        public int AccountID { get; set; }
        public string CName { get; set; }
        public decimal Balance { get => balance; set { balance = value; State.CheckState(); } }

        decimal balance;
        ///Composition
        internal IState State;

        public BankAccount(decimal Amount)
        {
            if (Amount < 0)
                State = new RedState(this);
            else if (Amount < 10_000)
                State = new SilverState(this);
            else
                State = new GoldStat(this);
        }

        ///Delegation
        public decimal PerformPayIntrest()
            => State.PayIntrest();

        public bool CheckLoanAmount(decimal Amount) => State.CheckLoanAmount(Amount);
    }
}
