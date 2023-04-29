using ClassLibrary;
using Grpc.Core;
using static PaymentService.PaymentChecker;

namespace PaymentService.Services
{
    public class CheckPaymentService : PaymentCheckerBase
    {
        public override Task<CheckPaymentReply> CheckPayment(CheckPaymentRequest request, ServerCallContext context)
        {
            var user = DummyDb.Users.FirstOrDefault(u => u.Id == request.Id);

            if (user == null || user.Balance < request.Due)
                return Task.FromResult(new CheckPaymentReply() { Approved = false });

            user.Balance -= request.Due;

            return Task.FromResult(new CheckPaymentReply() { Approved = true });
        }
    }
}
