using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDP.StateDP
{
    ///Abstract State
    internal interface IState
    {
        decimal PayIntrest();
        bool CheckLoanAmount(decimal Amount);

        void CheckState();
    }

    ///Concrete State
    ///State class per Enum Value


    class RedState : IState
    {
        BankAccount Context;
        public RedState(BankAccount account) => Context = account;

        public bool CheckLoanAmount(decimal Amount) => false;

        public decimal PayIntrest() => 0;

        public void CheckState()
        {
            if (Context.Balance > 0)
                Context.State = new SilverState(Context);
            else if ( Context.Balance >10_000)
                Context.State = new GoldStat(Context);

        }

    }

    class SilverState : IState
    {
        BankAccount Context;
        public SilverState(BankAccount account) => Context = account;

        public bool CheckLoanAmount(decimal Amount)
        {
            Console.WriteLine($"Up to {0.1M * Amount}");
            return true;
        }

        public decimal PayIntrest() => 0;

        public void CheckState()
        {
            if (Context.Balance < 0)
                Context.State = new RedState(Context);
            else if (Context.Balance > 10_000)
                Context.State = new GoldStat(Context);

        }
    }

    class GoldStat : IState
    {
        BankAccount Context;
        public GoldStat(BankAccount account) => Context = account;

        public bool CheckLoanAmount(decimal Amount)
        {
            Console.WriteLine($"Up To {0.9M * Amount}");
            return true;
        }

        public void CheckState()
        {
            if (Context.Balance < 0)
                Context.State = new RedState(Context);
            else if ( Context.Balance <10_000)
                Context.State = new SilverState(Context);

        }
        public decimal PayIntrest() => 0.05M * Context.Balance;
    }

}
