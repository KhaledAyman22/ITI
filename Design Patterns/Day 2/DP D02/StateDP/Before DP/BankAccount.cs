using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StateDP.Before_DP
{
    enum AccountState
    {
        Red , // <0
        Silver , // <10_000
        Gold ,// >10_000
        //VIP
    }
    internal class BankAccount
    {
        public int AccountID { get; set; }
        public string CName { get; set; }
        public decimal Balance { get; init; }

        AccountState accountState;

        public BankAccount(decimal Amount)
        {
            if (Amount < 0)
                accountState = AccountState.Red;
            else if (Amount < 10_000)
                accountState = AccountState.Silver;
            else
                accountState = AccountState.Gold;

            Balance = Amount;
        }

        public decimal PayIntrest ()
        {
            switch (accountState)
            {
                case AccountState.Red:
                case AccountState.Silver:
                    Console.WriteLine(  "No Inreset");
                    return 0;
                    break;
                case AccountState.Gold:
                    Console.WriteLine(  "Account Interest");
                    return Balance * 0.05M;
                    break;
                default:
                    return 0;
                    break;
            }
        }

        public bool CheckLoanAmount ( decimal Amount)
        {
            switch (accountState) 
            {
                case AccountState.Red:
                    return false;
                    break;
                case AccountState.Silver:
                    Console.WriteLine($"Loan Up to {0.1M * Amount}");
                    return true;
                    break;
                case AccountState.Gold:
                    Console.WriteLine($"Loan Up to {0.9M * Amount}");
                    return true;
                    break;
                default:
                    return false;
                    break;
            }
        }




    }
}
