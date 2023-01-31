namespace D09_PII
{
    internal class Program
    {
        static void Main(string[] args)
        {
            BankAccount BC1 = new() { AccountNumber = 101, CustName = "Ali", Balance = 5000 };
            BankAccount BC2 = new() { AccountNumber = 102, CustName = "Sally", Balance = 10_000 };

            EnterpriseBankAccount EBC = 
                new() { AccountNumber = 301, CompanyName = "Enterprise01", CustName = "Enterprise01", Balance = 2000 };

            CreditCardBankAccount CBC = new() { AccountNumber = 701, CustName = "Mena", Balance = 1000, Limit = 5000 };

            CustAgent Agent01 = new() { Name = "Agent01" };
            CustAgent Agent02 = new() { Name = "Agent02" };



            #region EX01

            //BC1.ExceedingBalance += Agent01.ContactClient;
            //BC1.ExceedingBalance += BlackList.AddToBlackList;

            //BC2.ExceedingBalance += Agent02.ContactClient;
            //BC2.ExceedingBalance += BlackList.AddToBlackList;



            //BC2.Debit(7000);

            //BC1.Debit(5050);

            //BC2.Debit(7000); 
            #endregion

            #region EX02
            //EBC.ExceedingBalance += Agent01.ContactClient;
            //EBC.ExceedingBalance += BlackList.AddToBlackList;

            //EBC.TransferSalary(5000, BC2); 
            #endregion

            CBC.ExceedingBalance += Agent02.ContactClient;
            CBC.ExceedingBalance += BlackList.AddToBlackList;


            CBC.Debit(3000);

            Console.WriteLine(BlackList.BlackListed);

        }
    }
}