//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace D09_PII
//{
//    public class BankAccount
//    {
//        public int AccountNumber { get; init; }
//        public string CustName { get; init; }
//        public decimal Balance { get; set; }

//        ///event Declaration
//        public event EventHandler ExceedingBalance;

//        protected virtual void OnExceedingBalance (EventArgs e)
//        {
//            ///Notify Subsc.
//            ExceedingBalance?.Invoke (this, e);
//        }

//        public bool Debit ( decimal Amount)
//        {
//            if (Amount>0)
//            {
//                if (Amount <= Balance)
//                {
//                    Balance -= Amount;
//                    return true;
//                }
//                else
//                    //Notify Subsc.
//                    OnExceedingBalance(new EventArgs());
//            }
//            return false;

//        }

//        public bool Credit (decimal Amount)
//        {
//            if ( Amount >0)
//            {
//                Balance += Amount;
//                return true;
//            }
//            return false;
//        }



//        public override string ToString()
//            => $"{AccountNumber} , {CustName} , {Balance}";
//    }
//}
