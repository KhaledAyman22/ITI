using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CarAPI.Payment
{
    public class CardService : IPaymentService
    {
        public string Pay(double amount)
        {
            // Logic
            return $"{amount} is paid successfully through card";
        }
    }
}