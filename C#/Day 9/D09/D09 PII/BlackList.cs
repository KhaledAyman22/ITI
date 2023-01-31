using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D09_PII
{
    /// <summary>
    /// Subsc.
    /// </summary>
    public static class BlackList
    {
        static List<string> bLst;

        public static int Size 
        {
            get => bLst.Count;
        }

        static BlackList() => bLst = new List<string>();

        ///CallbackMethod
        public static void AddToBlackList (object sender ,ExceedingBalanceEventArgs e)
        {
            if ((sender is BankAccount BC) && (BC != null)&&(e.DiffAmount >=100) &&(!bLst.Contains(BC.CustName)))
            {
                bLst.Add(BC.CustName);
            }
        }


        public static string BlackListed
        {
            get
            {
                StringBuilder stringBuilder = new StringBuilder();

                for ( int i=0; i < bLst.Count; i++ ) 
                    stringBuilder.Append(bLst[i] ).Append(" , ");
                
                return stringBuilder.ToString();
            }
        }
    }
}
