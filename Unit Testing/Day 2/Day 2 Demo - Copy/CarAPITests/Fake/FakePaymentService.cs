using CarAPI.Payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarAPITests.Fake
{
    public class FakePaymentService : IPaymentService
    {
        public string Pay(double amount)
        {
            return $"{amount} is paid through fake service";
        }
    }
}
