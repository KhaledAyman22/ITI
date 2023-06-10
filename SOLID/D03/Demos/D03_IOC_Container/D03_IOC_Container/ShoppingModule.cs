using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace D03_IOC_Container
{
    interface ICreditCard
    {
        void Charge();
    }

    internal class VisaCard : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using Visa Card........");
        }
    }

    internal class MasterCard : ICreditCard
    {
        public void Charge()
        {
            Console.WriteLine("Charging using MasterCard........");
        }
    }

    internal class Shopper
    {
        internal void Checkout(ICreditCard card)
        {
            // 1. code to handle check out process
            // 2. charging with card for checkout 
            card.Charge();
        }
    }
}
